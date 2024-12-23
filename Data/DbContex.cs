using Microsoft.EntityFrameworkCore;

public class PinguNotesContext : DbContext
{
    public PinguNotesContext(DbContextOptions<PinguNotesContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Nota> Notas { get; set; }
    public DbSet<Etiqueta> Etiquetas { get; set; }
    public DbSet<NotaEtiqueta> NotaEtiquetas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NotaEtiqueta>()
            .HasKey(ne => new { ne.NotaId, ne.EtiquetaId });

        modelBuilder.Entity<NotaEtiqueta>()
            .HasOne(ne => ne.Nota)
            .WithMany(n => n.NotaEtiquetas)
            .HasForeignKey(ne => ne.NotaId);

        modelBuilder.Entity<NotaEtiqueta>()
            .HasOne(ne => ne.Etiqueta)
            .WithMany(e => e.NotaEtiquetas)
            .HasForeignKey(ne => ne.EtiquetaId);
    }
}