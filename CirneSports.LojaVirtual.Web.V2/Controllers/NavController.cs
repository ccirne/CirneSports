using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CirneSports.LojaVirtual.Web.V2.Models;
using CirneSports.LojaVirtual.Dominio.Repositorio;

namespace CirneSports.LojaVirtual.Web.V2.Controllers
{
    public class NavController : Controller
    {
        private ProdutoModeloRepositorio _repositorio;
        private ProdutosViewModel _model;

        // GET: Nav
        public ActionResult Index()
        {
            _repositorio = new ProdutoModeloRepositorio();            

            var produtos = _repositorio.ObterProdutosVitrine();

            _model = new ProdutosViewModel { Produtos = produtos };

            return View(_model);
        }

        [Route("nav/{id}/{marca}")]
        public ActionResult ObterProdutosPorMarca (string id)
        {
            var model = new ProdutosViewModel { Produtos = null };

            return View("Index", model);
        }
    }
}