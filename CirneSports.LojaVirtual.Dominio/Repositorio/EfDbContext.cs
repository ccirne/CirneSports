using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CirneSports.LojaVirtual.Dominio.Entidade;
using CirneSports.LojaVirtual.Dominio.Entidade.Vitrine;
using Microsoft.AspNet.Identity.EntityFramework;

// comandos para criar a estutura segurança no DB usando o Package Manager Console
// PM> Enable-Migrations
// PM> Add-Migration -project CirneSports.LojaVirtual.Dominio
// Name: --> informar um nome
// PM> Update-DataBase – aplica as alterações no banco de dados

namespace CirneSports.LojaVirtual.Dominio.Repositorio
{
    public class EfDbContext :  IdentityDbContext<Cliente>
    //public class EfDbContext : DbContext
    {
        public EfDbContext()
            : base(@"Data Source=CLAUDIOCIRNE-PC; Initial Catalog=CIRNESPORTS_DB; Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False")
        { 
        }
   

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<MarcaVitrine> MarcaVitrine { get; set; }
        public DbSet<ClubesNacionais> ClubesNacionais { get; set; }
        public DbSet<ClubesInternacionais> ClubesInternacionais { get; set; }
        public DbSet<Selecoes> Selecoes { get; set; }
        public DbSet<FaixaEtaria> FaixasEtarias { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<SubGrupo> SubGrupos { get; set; }
        public DbSet<Modalidade> Modalidades { get; set; }
        public DbSet<ProdutoVitrine> ProdutoVitrine { get; set; }
        public DbSet<Tamanho> Tamanhos { get; set; }
        public DbSet<Cor> Cores { get; set; }
        public DbSet<CirneProduto> CirneProduto { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<ProdutoModelo> ProdutoModelo { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Produto>().ToTable("Produtos");
            modelBuilder.Entity<Administrador>().ToTable("Administradores");
            //modelBuilder.Entity<Categoria>().ToTable("Categorias");
            base.OnModelCreating(modelBuilder);
        }
    }
}
