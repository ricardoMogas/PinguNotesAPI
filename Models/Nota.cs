using System;
using System.Collections.Generic;

public class Nota
{
    public int Id { get; set; }
    public required string Titulo { get; set; }
    public required string Contenido { get; set; }
    public DateTime FechaCreacion { get; set; }
    public int UsuarioId { get; set; }
    public bool EsPublica { get; set; }

    public required Usuario Usuario { get; set; }
    public required ICollection<NotaEtiqueta> NotaEtiquetas { get; set; }
}