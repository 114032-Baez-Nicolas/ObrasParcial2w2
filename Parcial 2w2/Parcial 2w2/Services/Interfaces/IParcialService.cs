using Parcial_2w2.Dominio;
using Parcial_2w2.Dominio.Response;

namespace Parcial_2w2.Services.Interfaces;

public interface IParcialService
{
    //1) Obtener todas las obras
    Task<BaseReponse<List<GetObrasDto>>> ObtenerObrasAsync();

    //2) Post albanil x obra
    Task<BaseReponse<PostAlbanilXObraDto>> PostAlbanilXObraAsync(PostAlbanilXObraDto albXObra);

    //3) Post de Albanil
    Task<BaseReponse<PostAlbanilDto>> PostAlbanilAsync(PostAlbanilDto albanil);

    //4) Obtener albaniles que no forman parte de la obra que se pasa por parametro
    Task<BaseReponse<List<GetAlbanilesDto>>> ObtenerAlbanilesNoParteObraAsync(Guid idObra);

    //5) Obtener todos los albañiles
    Task<BaseReponse<List<GetAlbanilesDto>>> ObtenerAlbanilesAsync();
}
