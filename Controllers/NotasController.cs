using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


[ApiController]
[Route("api/[controller]")]
public class NotasController : ControllerBase
{
    private readonly INotaService _notaService;

    public NotasController(INotaService notaService)
    {
        _notaService = notaService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Nota>>> GetNotas()
    {
        var notas = await _notaService.GetNotasAsync();
        return Ok(notas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Nota>> GetNota(int id)
    {
        var nota = await _notaService.GetNotaByIdAsync(id);
        if (nota == null)
        {
            return NotFound();
        }
        return Ok(nota);
    }

    [HttpPost]
    public async Task<ActionResult<Nota>> CreateNota(CreateNotaDto createNotaDto)
    {
        var nota = new Nota
        {
            Titulo = createNotaDto.Titulo,
            Contenido = createNotaDto.Contenido,
            FechaCreacion = createNotaDto.FechaCreacion,
            UsuarioId = createNotaDto.UsuarioId,
            EsPublica = createNotaDto.EsPublica,
            Usuario = createNotaDto.Usuario,
            NotaEtiquetas = createNotaDto.NotaEtiquetas
        };

        var createdNota = await _notaService.CreateNotaAsync(nota);
        return CreatedAtAction(nameof(GetNota), new { id = createdNota.Id }, createdNota);
    }
}

