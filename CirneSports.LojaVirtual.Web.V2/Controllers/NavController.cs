using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CirneSports.LojaVirtual.Web.V2.Models;

namespace CirneSports.LojaVirtual.Web.V2.Controllers
{
    public class NavController : Controller
    {
        // GET: Nav
        public ActionResult Index()
        {
            return View();
        }

        [Route("nav/{id}/{marca}")]
        public ActionResult ObterProdutosPorMarca (string id)
        {
            var model = new ProdutosViewModel { Produtos = null };

            return View("Index", model);
        }
    }
}