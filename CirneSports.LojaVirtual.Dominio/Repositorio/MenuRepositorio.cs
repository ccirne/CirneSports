using System.Collections.Generic;
using System.Linq;
using CirneSports.LojaVirtual.Dominio.Entidade;
using CirneSports.LojaVirtual.Dominio.Entidade.Vitrine;

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
    }
}
