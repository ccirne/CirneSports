using CirneSports.LojaVirtual.Dominio.Entidade;
using CirneSports.LojaVirtual.Dominio.Repositorio;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace CirneSports.LojaVirtual.Web.V2.Models
{
    public class CirneSportsUserManager : UserManager<Cliente>
    {
        public CirneSportsUserManager(IUserStore<Cliente> store) : base(store) { }

        public static CirneSportsUserManager Create(IdentityFactoryOptions<CirneSportsUserManager> options, IOwinContext context)
        {
            var userManager = new CirneSportsUserManager(new UserStore<Cliente>(new EfDbContext()));

            return userManager;
        }
    }
}