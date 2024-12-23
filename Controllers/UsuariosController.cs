using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuariosController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
    {
        var usuarios = await _usuarioService.GetUsuariosAsync();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Usuario>> GetUsuario(int id)
    {
        var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
        if (usuario == null)
        {
            return NotFound();
        }
        return Ok(usuario);
    }

    [HttpPost]
    public async Task<ActionResult<Usuario>> CreateUsuario(CreateUsuarioDto createUsuarioDto)
    {
        var usuario = new Usuario
        {
            Nombre = createUsuarioDto.Nombre,
            Email = createUsuarioDto.Email,
            Password = createUsuarioDto.Password
        };

        var createdUsuario = await _usuarioService.CreateUsuarioAsync(usuario);
        return CreatedAtAction(nameof(GetUsuario), new { id = createdUsuario.Id }, createdUsuario);
    }
}