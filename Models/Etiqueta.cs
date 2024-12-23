using System.Collections.Generic;

public class Etiqueta
{
    public int Id { get; set; }
    public required string Nombre { get; set; }
    public required string Color { get; set; }

    public required ICollection<NotaEtiqueta> NotaEtiquetas { get; set; }
}