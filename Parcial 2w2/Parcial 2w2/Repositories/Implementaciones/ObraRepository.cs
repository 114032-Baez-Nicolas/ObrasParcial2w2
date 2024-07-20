using Microsoft.EntityFrameworkCore;
using Parcial_2w2.ModelsDatabase;
using Parcial_2w2.Repositories.Interfaces;

namespace Parcial_2w2.Repositories.Implementaciones;

public class ObraRepository : IObrasRepository
{
    private readonly DbAa579fProg3w2Context _context;

    public ObraRepository(DbAa579fProg3w2Context dbAa579FProg3W2Context)
    {
        _context = dbAa579FProg3W2Context;  
    }

    //1) Obtener todas las obras
    public async Task<List<Obra>> ObtenerObrasAsync()
    {
        return await _context.Obras
            .Include(x => x.AlbanilesXObras)
            .Include(x => x.IdTipoObraNavigation)
            .ToListAsync();
    }

    //2) Post albanile x obra
    public async Task PostAlbanilXObraAsync(AlbanilesXObra albXObra)
    {
        await _context.AlbanilesXObras.AddAsync(albXObra);
        await _context.SaveChangesAsync();
    }

    //3) Obtener albaniles que no forman parte de la obra
    public async Task<List<Albanile>> ObtenerAlbanilesNoParteObraAsync(Guid idObra)
    {
        var albaniles = await _context.Albaniles
            .Where(x => !_context.AlbanilesXObras.Any(y => y.IdAlbanil == x.Id && y.IdObra == idObra))
            .ToListAsync();

        return albaniles;
    }

    //4) Validar que la obra exista
    public async Task<bool> ValidarObraExistenteAsync(Guid idObra)
    {
        return await _context.Obras.AnyAsync(x => x.Id == idObra);
    }
}
