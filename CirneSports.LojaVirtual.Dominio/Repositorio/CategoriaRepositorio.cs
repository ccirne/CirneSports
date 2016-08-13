using System.Collections.Generic;
using System.Linq;
using CirneSports.LojaVirtual.Dominio.Entidade;

namespace CirneSports.LojaVirtual.Dominio.Repositorio
{
    public class CategoriaRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable <Categoria> ObterCategoria()
        {
            return _context.Categorias.OrderBy(c => c.CategoriaDescricao);
        }
    }
}
