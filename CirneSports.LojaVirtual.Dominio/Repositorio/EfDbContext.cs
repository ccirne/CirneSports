using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CirneSports.LojaVirtual.Dominio.Entidade;

namespace CirneSports.LojaVirtual.Dominio.Repositorio
{
    public class EfDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Administrador> Administradores { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Produto>().ToTable("Produtos");
            modelBuilder.Entity<Administrador>().ToTable("Administradores");
            //modelBuilder.Entity<Categoria>().ToTable("Categorias");
            //base.OnModelCreating(modelBuilder);
        }
    }
}
