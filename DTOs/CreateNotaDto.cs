public class CreateNotaDto
{
    public string Titulo { get; set; }
    public string Contenido { get; set; }
    public DateTime FechaCreacion { get; set; }
    public int UsuarioId { get; set; }
    public bool EsPublica { get; set; }
    public List<NotaEtiqueta> NotaEtiquetas { get; set; }
    public Usuario Usuario { get; set; } // Add this line
}