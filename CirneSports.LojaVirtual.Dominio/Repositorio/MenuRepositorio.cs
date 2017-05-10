using System.Collections.Generic;
using System.Linq;
using CirneSports.LojaVirtual.Dominio.Entidade;
using CirneSports.LojaVirtual.Dominio.Entidade.Vitrine;
using CirneSports.LojaVirtual.Dominio.Dto;
using FastMapper;

namespace CirneSports.LojaVirtual.Dominio.Repositorio
{
    public class MenuRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Categoria> ObterCategorias()
        {
            return _context.Categorias.OrderBy(c => c.CategoriaDescricao);
        }

        public IEnumerable<MarcaVitrine> ObterMarcas()
        {
            return _context.MarcaVitrine.OrderBy(m => m.MarcaDescricao);
        }

        public IEnumerable<ClubesNacionais> ObterClubesNacionais()
        {
            return _context.ClubesNacionais.OrderBy(n => n.LinhaDescricao);
        }

        public IEnumerable<ClubesInternacionais> ObterClubesInternacionais()
        {
            return _context.ClubesInternacionais.OrderBy(i => i.LinhaDescricao);
        }

        public IEnumerable<Selecoes> ObterSelecoes()
        {
            return _context.Selecoes.OrderBy(s => s.LinhaDescricao);
        }

        public IEnumerable<FaixaEtaria> ObterFaixaEtarias()
        {
            return _context.FaixasEtarias.OrderBy(s => s.FaixaEtariaDescricao);
        }

        public IEnumerable<Genero> ObterGeneros()
        {
            return _context.Generos.OrderBy(s => s.GeneroDescricao);
        }

        public IEnumerable<Grupo> ObterGrupos()
        {
            return _context.Grupos.OrderBy(s => s.GrupoDescricao);
        }

        public IEnumerable<Modalidade> ObterModalidades()
        {
            return _context.Modalidades.OrderBy(s => s.ModalidadeDescricao);
        }

        public IEnumerable<SubGrupo> ObterSubGrupos()
        {
            return _context.SubGrupos.OrderBy(s => s.SubGrupoDescricao);
        }

        public IEnumerable<Categoria> ObterTenisCategotia()
        {
            var categorias = new[] { "0005", "0082", "0112", "0010", "0006", "0063" };
            return _context.Categorias.Where(c => categorias.Contains(c.CategoriaCodigo)).OrderBy(c => c.CategoriaDescricao);
        }

        public SubGrupo ObterSubGruposTenis()
        {
            return _context.SubGrupos.FirstOrDefault(s => s.SubGrupoCodigo == "0084");
        }

        public Modalidade ObterModalidadeCasual()
        {
            const string CodigoModalidade = "0001";
            return _context.Modalidades.FirstOrDefault(m => m.ModalidadeCodigo == CodigoModalidade);
        }

        //executar no Package Manager Console "PM>Install-Package FastMapper"
        public IEnumerable<SubGrupoDto> ObterCasualSubGrupo()
        {
            var subgrupos = new[] { "0001", "0102", "0103", "0738", "0084", "0921" };

            var query = from s in _context.SubGrupos
                        .Where(s => subgrupos.Contains(s.SubGrupoCodigo))
                        .Select(s => new { s.SubGrupoCodigo, s.SubGrupoDescricao })
                        .Distinct()
                        .OrderBy(s => s.SubGrupoDescricao)

                        select new
                        {
                            s.SubGrupoCodigo,
                            s.SubGrupoDescricao
                        };

            return query.Project().To<SubGrupoDto>().ToList();

        }

        public Categoria ObterSuplemento()
        {
            const string categoriaSuplemento = "0008";
            return _context.Categorias.FirstOrDefault(c => c.CategoriaCodigo == categoriaSuplemento);
        }

        public IEnumerable<SubGrupo> ObterSuplementoSubGrupo()
        {
            var subgrupos = new[] { "0162", "0381", "0557", "0564", "0565", "0977", "1082", "1083", "1084", "1085" };

            return _context.SubGrupos
                   .Where(s => subgrupos.Contains(s.SubGrupoCodigo) && s.GrupoCodigo == "0012")
                   .Distinct()
                   .OrderBy(s => s.SubGrupoDescricao);
        }
    }
}
