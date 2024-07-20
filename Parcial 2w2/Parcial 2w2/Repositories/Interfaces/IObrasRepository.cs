using Parcial_2w2.ModelsDatabase;

namespace Parcial_2w2.Repositories.Interfaces;

public interface IObrasRepository
{
    //1) Obtener todas las obras
    Task<List<Obra>> ObtenerObrasAsync();

    //2) Post albanile x obra
    Task PostAlbanilXObraAsync(AlbanilesXObra albXObra);

    //3) Obtener albaniles que no forman parte de la obra
    Task<List<Albanile>> ObtenerAlbanilesNoParteObraAsync(Guid idObra);

    //4) Validar que la obra exista
    Task<bool> ValidarObraExistenteAsync(Guid idObra);
}
