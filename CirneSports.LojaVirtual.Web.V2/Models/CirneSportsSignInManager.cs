using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CirneSports.LojaVirtual.Dominio.Entidade;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace CirneSports.LojaVirtual.Web.V2.Models
{
    public class CirneSportsSignInManager : SignInManager<Cliente, string>
    {
        public CirneSportsSignInManager(CirneSportsUserManager userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager) { }

        public static CirneSportsSignInManager Create(IdentityFactoryOptions<CirneSportsSignInManager> option, IOwinContext context)
        {
            var manager = context.GetUserManager<CirneSportsUserManager>();
            var sign = new CirneSportsSignInManager(manager, context.Authentication);
            return sign;
        }
    }
}