﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CirneSports.LojaVirtual.Dominio.Entidade;
using CirneSports.LojaVirtual.Dominio.Entidade.Vitrine;

namespace CirneSports.LojaVirtual.Dominio.Repositorio
{
    public class EfDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Administrador> Administradores { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<MarcaVitrine> MarcaVitrine { get; set; }

        public DbSet<ClubesNacionais> ClubesNacionais { get; set; }

        public DbSet<ClubesInternacionais> ClubesInternacionais { get; set; }

        public DbSet<Selecoes> Selecoes { get; set; }

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
