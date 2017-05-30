using CirneSports.LojaVirtual.Dominio.Entidade;

namespace CirneSports.LojaVirtual.Dominio.Repositorio
{
    public class ClientesRepositorio
    {
       private readonly EfDbContext _context = new EfDbContext();

        public Cliente ObterCliente(string id)
        {
            return _context.Users.Find(id);
        }
    }
}
