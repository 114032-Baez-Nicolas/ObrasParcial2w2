using Parcial_2w2.ModelsDatabase;

namespace Parcial_2w2.Repositories.Interfaces;

public interface IAlbanileRepository
{
    //1) Obtener todos los albañiles
    Task<List<Albanile>> ObtenerAlbanilesAsync();

    //2) Post albañil
    Task PostAlbanilAsync(Albanile albanil);

    //3) Validare que el albañil no se repita
    Task<bool> ValidarAlbanilAsync(string dni);

    //4) Validar que el albañil exista
    Task<bool> ValidarAlbanilExistenteAsync(Guid idAlbanil);

}
