using elibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace elibrary.Data
{
    public class AppDbContext: DbContext 
    {
        public AppDbContext(DbContextOptions options) : base (options) { }
       
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor_Ksiazka>().HasKey(am => new
            {
                am.KsiazkaId,
                am.AutorId
            });
            modelBuilder.Entity<Autor_Ksiazka>().HasOne (m => m.Ksiazki).WithMany(am  => am.Autor_Ksiazki).HasForeignKey (m =>
            m.KsiazkaId);
            modelBuilder.Entity<Autor_Ksiazka>().HasOne(m => m.Autorzy).WithMany(am => am.Autor_Ksiazki).HasForeignKey(m =>
            m.AutorId);
            base.OnModelCreating(modelBuilder);
        }
    public DbSet<Biblioteka> Biblioteki { get; set; }
    public DbSet<Autor> Autorzy { get; set; }
    public DbSet<Ksiazka> Ksiazki { get; set; }
    public DbSet<Wydawnictwo> Wydawnictwa { get; set; }
    public DbSet<Autor_Ksiazka> Autor_Ksiazki { get; set; }
    }
}
