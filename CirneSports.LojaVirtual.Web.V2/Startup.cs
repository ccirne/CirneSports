using Microsoft.Owin;
using System;
using CirneSports.LojaVirtual.Web.V2;
using CirneSports.LojaVirtual.Dominio.Repositorio;
using CirneSports.LojaVirtual.Web.V2.Models;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartupAttribute(typeof(CirneSports.LojaVirtual.Web.V2.Startup))]
namespace CirneSports.LojaVirtual.Web.V2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(EfDbContext.Create);
            app.CreatePerOwinContext<CirneSportsUserManager>(CirneSportsUserManager.Create);
            app.CreatePerOwinContext<CirneSportsSignInManager>(CirneSportsSignInManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/cliente/login"),                
                CookieName = "clienteLogin",
                CookiePath = "/",
                ExpireTimeSpan = TimeSpan.FromHours(12)
            }); 
        }
    }
}