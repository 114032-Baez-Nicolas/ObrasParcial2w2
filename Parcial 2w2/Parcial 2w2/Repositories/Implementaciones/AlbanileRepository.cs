using Microsoft.EntityFrameworkCore;
using Parcial_2w2.ModelsDatabase;
using Parcial_2w2.Repositories.Interfaces;

namespace Parcial_2w2.Repositories.Implementaciones;

public class AlbanileRepository : IAlbanileRepository
{
    private readonly DbAa579fProg3w2Context _context;

    public AlbanileRepository(DbAa579fProg3w2Context dbAa579FProg3W2Context)
    {
        _context = dbAa579FProg3W2Context;
    }

    //1) Obtener todos los albañiles
    public async Task<List<Albanile>> ObtenerAlbanilesAsync()
    {
        return await _context.Albaniles.ToListAsync();
    }

    //2) Post albañil
    public async Task PostAlbanilAsync(Albanile albanil)
    {
        await _context.Albaniles.AddAsync(albanil);
        await _context.SaveChangesAsync();
    }

    //3) Validare que el albañil no se repita
    public async Task<bool> ValidarAlbanilAsync(string dni)
    {
        return await _context.Albaniles.AnyAsync(x => x.Dni == dni);
    }

    //4) Validar que el albañil exista
    public async Task<bool> ValidarAlbanilExistenteAsync(Guid idAlbanil)
    {
        return await _context.Albaniles.AnyAsync(x => x.Id == idAlbanil);
    
    }
}
