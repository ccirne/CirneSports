using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CirneSports.LojaVirtual.Dominio.Repositorio;

namespace CirneSports.LojaVirtual.Web.V2.Controllers
{
    [Authorize]
    public class PedidosController : Controller
    {
        private PedidosRepositorio _repositorio = new PedidosRepositorio();

        public ActionResult Index()
        {
            string id = User.Identity.GetUserId();
            var pedidos = _repositorio.ObterPedidos(id);
            return View(pedidos);
        }

        public ActionResult Details(int id)
        {
            var pedido = _repositorio.ObterPedido(id);
            return View(pedido);
        }
    }
}