using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using CirneSports.LojaVirtual.Dominio.Entidade;
using CirneSports.LojaVirtual.Web.App_Start;
using CirneSports.LojaVirtual.Web.Infraestrutura;

namespace CirneSports.LojaVirtual.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelBinders.Binders.Add(typeof(Carrinho), new CarrinhoModelBinder());
        }
    }
}
