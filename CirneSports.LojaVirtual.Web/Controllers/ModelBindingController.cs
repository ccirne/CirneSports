using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CirneSports.LojaVirtual.Dominio.Entidade;

namespace CirneSports.LojaVirtual.Web.Controllers
{
    public class ModelBindingController : Controller
    {
        // GET: ModelBinding
        public ActionResult Index()
        {
            return View(new Produto());
        }

        [HttpPost]
        public ActionResult Editar()
        {
            var produto = new Produto();

            return RedirectToAction("Index");
        }
    }
}