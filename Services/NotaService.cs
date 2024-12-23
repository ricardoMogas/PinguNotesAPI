using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class NotaService : INotaService
{
    private readonly PinguNotesContext _context;

    public NotaService(PinguNotesContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Nota>> GetNotasAsync()
    {
        return await _context.Notas.ToListAsync();
    }

    public async Task<Nota> GetNotaByIdAsync(int id)
    {
        return await _context.Notas.FindAsync(id);
    }

    public async Task<Nota> CreateNotaAsync(Nota nota)
    {
        _context.Notas.Add(nota);
        await _context.SaveChangesAsync();
        return nota;
    }
}