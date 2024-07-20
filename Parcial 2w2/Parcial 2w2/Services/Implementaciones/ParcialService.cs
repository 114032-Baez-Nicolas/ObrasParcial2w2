using AutoMapper;
using Parcial_2w2.Dominio;
using Parcial_2w2.Dominio.Response;
using Parcial_2w2.ModelsDatabase;
using Parcial_2w2.Repositories.Interfaces;
using Parcial_2w2.Services.Interfaces;
using Parcial_2w2.Validators;

namespace Parcial_2w2.Services.Implementaciones;

public class ParcialService : IParcialService
{
    private readonly IObrasRepository _obrasRepository;
    private readonly IAlbanileRepository _albanileRepository;
    private readonly IMapper _mapper;
    private readonly PostAlbanilXObraDtoValidator _postAlbanilXObraDtoValidator;
    private readonly PostAlbanilDtoValidator _postAlbanilDtoValidator;

    public ParcialService(IObrasRepository obrasRepository, IAlbanileRepository albanileRepository, IMapper mapper,
        PostAlbanilXObraDtoValidator validatorAlbanilexObra, PostAlbanilDtoValidator postAlbanilDtoValidator)
    {
        _obrasRepository = obrasRepository;
        _albanileRepository = albanileRepository;
        _mapper = mapper;
        _postAlbanilXObraDtoValidator = validatorAlbanilexObra;
        _postAlbanilDtoValidator = postAlbanilDtoValidator;
    }

    //1) Obtener todas las obras
    public async Task<BaseReponse<List<GetObrasDto>>> ObtenerObrasAsync()
    {
        var response = new BaseReponse<List<GetObrasDto>>();

        try
        {
            var obras = await _obrasRepository.ObtenerObrasAsync();
            response.Data = _mapper.Map<List<GetObrasDto>>(obras);
            response.Success = true;
            response.Message = "Se obtuvieron las obras exitosamente..";
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = "Ocurrio un error al obtener las obras..";
            throw;
        }

        return response;
    }

    //2) Post albanil x obra
    public async Task<BaseReponse<PostAlbanilXObraDto>> PostAlbanilXObraAsync(PostAlbanilXObraDto albXObra)
    {
        var response = new BaseReponse<PostAlbanilXObraDto>();

        var validationResult = await _postAlbanilXObraDtoValidator.ValidateAsync(albXObra);

        if (!validationResult.IsValid)
        {
            var errors = string.Join(", ", validationResult.Errors.Select(x => x.ErrorMessage));
            response.Success = false;
            response.Message = errors;
            return response;
        }


        try
        {

            var albanil = await _albanileRepository.ValidarAlbanilExistenteAsync(albXObra.IdAlbanil);

            if (!albanil)
            {
                response.Success = false;
                response.Message = "Error, el albañil no existe..";
                return response;
            }

            var obra = await _obrasRepository.ValidarObraExistenteAsync(albXObra.IdObra);

            if (!obra)
            {
                response.Success = false;
                response.Message = "La obra no existe..";
                return response;
            }

            var albXObraEntity = _mapper.Map<AlbanilesXObra>(albXObra);
            albXObraEntity.Id = Guid.NewGuid();
            albXObraEntity.FechaAlta = DateTime.Now;

            await _obrasRepository.PostAlbanilXObraAsync(albXObraEntity);

            response.Data = albXObra;
            response.Success = true;
            response.Message = "Se agrego el albañil a la obra exitosamente..";
        }
        catch (Exception)
        {
            response.Success = false;
            response.Message = "Ocurrio un error al agregar el albañil a la obra..";
            throw;
        }

        return response;
    }

    //3) Post de Albanil
    public async Task<BaseReponse<PostAlbanilDto>> PostAlbanilAsync(PostAlbanilDto albanil)
    {
        var response = new BaseReponse<PostAlbanilDto>();

        var validationResult = await _postAlbanilDtoValidator.ValidateAsync(albanil);

        if (!validationResult.IsValid)
        {
            var errors = string.Join(" | ", validationResult.Errors.Select(x => x.ErrorMessage));
            response.Success = false;
            response.Message = errors;
            return response;
        }

        try
        {
            var albanilExistente = await _albanileRepository.ValidarAlbanilAsync(albanil.Dni);

            if (albanilExistente)
            {
                response.Success = false;
                response.Message = "Error, el albañil ya existe..";
                return response;
            }

            var albanilEntity = _mapper.Map<Albanile>(albanil);
            albanilEntity.Id = Guid.NewGuid();
            albanilEntity.Activo = true;
            albanilEntity.FechaAlta = DateTime.Now;

            await _albanileRepository.PostAlbanilAsync(albanilEntity);

            response.Data = albanil;
            response.Success = true;
            response.Message = "Se agrego el albañil exitosamente..";
        }
        catch (Exception)
        {
            response.Success = false;
            response.Message = "Ocurrio un error al agregar el albañil..";
            throw;
        }

        return response;
    }

    //4) Obtener albaniles que no forman parte de la obra que se pasa por parametro
    public async Task<BaseReponse<List<GetAlbanilesDto>>> ObtenerAlbanilesNoParteObraAsync(Guid idObra)
    {
        var response = new BaseReponse<List<GetAlbanilesDto>>();

        try
        {
            var obra = await _obrasRepository.ValidarObraExistenteAsync(idObra);

            if (!obra)
            {
                response.Success = false;
                response.Message = "La obra no existe..";
                return response;
            }

            var albaniles = await _obrasRepository.ObtenerAlbanilesNoParteObraAsync(idObra);
            response.Data = _mapper.Map<List<GetAlbanilesDto>>(albaniles);
            response.Success = true;
            response.Message = "Se obtuvieron los albañiles exitosamente..";
        }
        catch (Exception)
        {
            response.Success = false;
            response.Message = "Ocurrio un error al obtener los albañiles..";
            throw;
        }

        return response;
    }

    //5) Obtener todos los albañiles
    public async Task<BaseReponse<List<GetAlbanilesDto>>> ObtenerAlbanilesAsync()
    {
        var response = new BaseReponse<List<GetAlbanilesDto>>();

        try
        {
            var albaniles = await _albanileRepository.ObtenerAlbanilesAsync();
            response.Data = _mapper.Map<List<GetAlbanilesDto>>(albaniles);
            response.Success = true;
            response.Message = "Se obtuvieron los albañiles exitosamente..";
        }
        catch (Exception)
        {
            response.Success = false;
            response.Message = "Ocurrio un error al obtener los albañiles..";
            throw;
        }

        return response;
    }

}
