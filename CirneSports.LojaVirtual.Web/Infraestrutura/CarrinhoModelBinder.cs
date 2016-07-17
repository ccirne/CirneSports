using System.Web.Mvc;
using CirneSports.LojaVirtual.Dominio.Entidade;
//using IModelBinder = System.Web.Http.ModelBinding.IModelBinder;
//using ModelBindingContext = System.Web.Http.ModelBinding.ModelBindingContext;

namespace CirneSports.LojaVirtual.Web.Infraestrutura
{
    public class CarrinhoModelBinder : IModelBinder
    {
        private const string SessionKey = "Carrinho";

        //IModelBinder interface define o método BindModel
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //Obtenho o carrinho da sessão
            Carrinho carrinho = null;

            if (controllerContext.HttpContext.Session != null)
            {
                carrinho = (Carrinho)controllerContext.HttpContext.Session[SessionKey];
            }

            //Crio o carrinho se não tenho a sessão
            if (carrinho == null)
            {
                carrinho = new Carrinho();

                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[SessionKey] = carrinho;
                }
            }

            //Retorno o carrinho
            return carrinho;
        }
    }
}