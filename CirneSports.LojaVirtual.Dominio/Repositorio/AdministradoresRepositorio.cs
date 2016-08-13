using System.Linq;
using CirneSports.LojaVirtual.Dominio.Entidade;

namespace CirneSports.LojaVirtual.Dominio.Repositorio
{
    public class AdministradoresRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        public Administrador ObterAdiministrador(Administrador administrador)
        {
            return _context.Administradores.FirstOrDefault(a => a.Login == administrador.Login);
        }
    }
}
