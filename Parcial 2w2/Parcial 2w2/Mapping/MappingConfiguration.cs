using AutoMapper;
using Parcial_2w2.Dominio;
using Parcial_2w2.ModelsDatabase;

namespace Parcial_2w2.Mapping;

public class MappingConfiguration : Profile
{
    public MappingConfiguration()
    {
        //------GETS------
        CreateMap<Obra, GetObrasDto>()
            .ForMember(dest => dest.NombreObra, opt => opt.MapFrom(src => src.IdTipoObraNavigation.Nombre))
            .ForMember(dest => dest.CantidadAlbaniles, opt => opt.MapFrom(src => src.AlbanilesXObras.Count));

        CreateMap<Albanile, GetAlbanilesDto>().ReverseMap();

        //------POSTS------
        CreateMap<AlbanilesXObra, PostAlbanilXObraDto>().ReverseMap();
        CreateMap<Albanile, PostAlbanilDto>().ReverseMap();
    }
}
