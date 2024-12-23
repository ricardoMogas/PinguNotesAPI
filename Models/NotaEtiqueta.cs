public class NotaEtiqueta
{
    public int NotaId { get; set; }
    public int EtiquetaId { get; set; }

    public Nota? Nota { get; set; }
    public Etiqueta? Etiqueta { get; set; }
}