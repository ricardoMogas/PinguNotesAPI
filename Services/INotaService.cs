using System.Collections.Generic;
using System.Threading.Tasks;

public interface INotaService
{
    Task<IEnumerable<Nota>> GetNotasAsync();
    Task<Nota> GetNotaByIdAsync(int id);
    Task<Nota> CreateNotaAsync(Nota nota);
}