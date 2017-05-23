namespace CirneSports.LojaVirtual.Dominio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarClienteDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administradores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        Senha = c.String(nullable: false),
                        UltimoAcesso = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        CategoriaCodigo = c.String(),
                        CategoriaDescricao = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.CirneProduto",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        ProdutoCodigo = c.String(),
                        ProdutoModeloCodigo = c.String(),
                        CorCodigo = c.String(),
                        TamanhoCodigo = c.String(),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProdutoDescricao = c.String(),
                        ProdutoDescricaoResumida = c.String(),
                        MarcaDescricao = c.String(),
                        ModeloDescricao = c.String(),
                        UnidadeVenda = c.String(),
                    })
                .PrimaryKey(t => t.ProdutoId);
            
            CreateTable(
                "dbo.ClubesInternacionais",
                c => new
                    {
                        LinhaCodigo = c.String(nullable: false, maxLength: 128),
                        LinhaDescricao = c.String(),
                    })
                .PrimaryKey(t => t.LinhaCodigo);
            
            CreateTable(
                "dbo.ClubesNacionais",
                c => new
                    {
                        LinhaCodigo = c.String(nullable: false, maxLength: 128),
                        LinhaDescricao = c.String(),
                    })
                .PrimaryKey(t => t.LinhaCodigo);
            
            CreateTable(
                "dbo.Cor",
                c => new
                    {
                        CorId = c.Int(nullable: false, identity: true),
                        CorDescricao = c.String(),
                        CorCodigo = c.String(),
                        Tamanho = c.String(),
                    })
                .PrimaryKey(t => t.CorId);
            
            CreateTable(
                "dbo.Estoque",
                c => new
                    {
                        EstoqueId = c.Int(nullable: false, identity: true),
                        ProdutoCodigo = c.String(),
                        Quantidade = c.Int(nullable: false),
                        DataAtualizacao = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EstoqueId);
            
            CreateTable(
                "dbo.FaixaEtaria",
                c => new
                    {
                        FaixaEtariaId = c.Int(nullable: false, identity: true),
                        FaixaEtariaCodigo = c.String(),
                        FaixaEtariaDescricao = c.String(),
                    })
                .PrimaryKey(t => t.FaixaEtariaId);
            
            CreateTable(
                "dbo.Genero",
                c => new
                    {
                        GeneroId = c.Int(nullable: false, identity: true),
                        GeneroCodigo = c.String(),
                        GeneroDescricao = c.String(),
                    })
                .PrimaryKey(t => t.GeneroId);
            
            CreateTable(
                "dbo.Grupo",
                c => new
                    {
                        GrupoId = c.Int(nullable: false, identity: true),
                        GrupoCodigo = c.String(),
                        GrupoDescricao = c.String(),
                    })
                .PrimaryKey(t => t.GrupoId);
            
            CreateTable(
                "dbo.Marca",
                c => new
                    {
                        MarcaId = c.Int(nullable: false, identity: true),
                        MarcaCodigo = c.String(),
                        MarcaDescricao = c.String(),
                    })
                .PrimaryKey(t => t.MarcaId);
            
            CreateTable(
                "dbo.MarcaVitrine",
                c => new
                    {
                        MarcaCodigo = c.String(nullable: false, maxLength: 128),
                        MarcaDescricao = c.String(),
                        MarcaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MarcaCodigo);
            
            CreateTable(
                "dbo.Modalidade",
                c => new
                    {
                        ModalidadeId = c.Int(nullable: false, identity: true),
                        ModalidadeCodigo = c.String(),
                        ModalidadeDescricao = c.String(),
                    })
                .PrimaryKey(t => t.ModalidadeId);
            
            CreateTable(
                "dbo.ProdutoModelo",
                c => new
                    {
                        ProdutoModeloId = c.Int(nullable: false, identity: true),
                        ProdutoModeloCodigo = c.String(),
                        ProdutoDescricao = c.String(),
                        UnidadeVenda = c.String(),
                        GrupoCodigo = c.String(),
                        SubGrupoCodigo = c.String(),
                        CategoriaCodigo = c.String(),
                        MarcaCodigo = c.String(),
                        GeneroCodigo = c.String(),
                        FaixaEtariaCodigo = c.String(),
                        ModalidadeCodigo = c.String(),
                        LinhaCodigo = c.String(),
                        MarcaDescricao = c.String(),
                        DescricaoResumida = c.String(),
                    })
                .PrimaryKey(t => t.ProdutoModeloId);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(nullable: false),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Categoria = c.String(nullable: false),
                        Imagem = c.Binary(),
                        ImagemMimeType = c.String(),
                    })
                .PrimaryKey(t => t.ProdutoId);
            
            CreateTable(
                "dbo.ProdutoVitrine",
                c => new
                    {
                        ProdutoModeloCor = c.String(nullable: false, maxLength: 128),
                        ProdutoDescricao = c.String(),
                        MarcaDescricao = c.String(),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GrupoCodigo = c.String(),
                        SubGrupoCodigo = c.String(),
                        CategoriaCodigo = c.String(),
                        MarcaCodigo = c.String(),
                        GeneroCodigo = c.String(),
                        FaixaEtariaCodigo = c.String(),
                        ModalidadeCodigo = c.String(),
                        LinhaCodigo = c.String(),
                    })
                .PrimaryKey(t => t.ProdutoModeloCor);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Selecoes",
                c => new
                    {
                        LinhaCodigo = c.String(nullable: false, maxLength: 128),
                        LinhaDescricao = c.String(),
                    })
                .PrimaryKey(t => t.LinhaCodigo);
            
            CreateTable(
                "dbo.SubGrupo",
                c => new
                    {
                        SubGrupoId = c.Int(nullable: false, identity: true),
                        GrupoCodigo = c.String(),
                        SubGrupoCodigo = c.String(),
                        SubGrupoDescricao = c.String(),
                    })
                .PrimaryKey(t => t.SubGrupoId);
            
            CreateTable(
                "dbo.Tamanho",
                c => new
                    {
                        TamanhoId = c.Int(nullable: false, identity: true),
                        TamanhoCodigo = c.String(),
                        TamanhoDescricaoResumida = c.String(),
                        TamanhoDescricao = c.String(),
                    })
                .PrimaryKey(t => t.TamanhoId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        NomeCompleto = c.String(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DocumentoCliente", t => t.Id)
                .ForeignKey("dbo.EnderecoCliente", t => t.Id)
                .ForeignKey("dbo.TelefoneCliente", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.DocumentoCliente",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Tipo = c.Int(nullable: false),
                        Valor = c.Long(nullable: false),
                        DtNasc = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EnderecoCliente",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Pais = c.String(),
                        Estado = c.String(),
                        Cidade = c.String(),
                        CEP = c.String(),
                        Bairro = c.String(),
                        Rua = c.String(),
                        Numero = c.String(),
                        Complemento = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClienteId = c.String(maxLength: 128),
                        EmbrulhaPresente = c.Boolean(nullable: false),
                        Pago = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.ProdutoPedido",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PedidoId = c.Int(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                        Quantidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pedido", t => t.PedidoId, cascadeDelete: true)
                .ForeignKey("dbo.CirneProduto", t => t.ProdutoId, cascadeDelete: true)
                .Index(t => t.PedidoId)
                .Index(t => t.ProdutoId);
            
            CreateTable(
                "dbo.TelefoneCliente",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CodigoArea = c.String(),
                        Numero = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Id", "dbo.TelefoneCliente");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProdutoPedido", "ProdutoId", "dbo.CirneProduto");
            DropForeignKey("dbo.ProdutoPedido", "PedidoId", "dbo.Pedido");
            DropForeignKey("dbo.Pedido", "ClienteId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Id", "dbo.EnderecoCliente");
            DropForeignKey("dbo.AspNetUsers", "Id", "dbo.DocumentoCliente");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.ProdutoPedido", new[] { "ProdutoId" });
            DropIndex("dbo.ProdutoPedido", new[] { "PedidoId" });
            DropIndex("dbo.Pedido", new[] { "ClienteId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.TelefoneCliente");
            DropTable("dbo.ProdutoPedido");
            DropTable("dbo.Pedido");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.EnderecoCliente");
            DropTable("dbo.DocumentoCliente");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Tamanho");
            DropTable("dbo.SubGrupo");
            DropTable("dbo.Selecoes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ProdutoVitrine");
            DropTable("dbo.Produtos");
            DropTable("dbo.ProdutoModelo");
            DropTable("dbo.Modalidade");
            DropTable("dbo.MarcaVitrine");
            DropTable("dbo.Marca");
            DropTable("dbo.Grupo");
            DropTable("dbo.Genero");
            DropTable("dbo.FaixaEtaria");
            DropTable("dbo.Estoque");
            DropTable("dbo.Cor");
            DropTable("dbo.ClubesNacionais");
            DropTable("dbo.ClubesInternacionais");
            DropTable("dbo.CirneProduto");
            DropTable("dbo.Categoria");
            DropTable("dbo.Administradores");
        }
    }
}
