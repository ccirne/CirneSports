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
        public ActionResult ObterProdutosPorMarca (string id, string marca)
        {
            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutosVitrine(marca: id);

            _model = new ProdutosViewModel { Produtos = produtos, Titulo = marca };

            return View("Navegacao", _model);
        }

        [Route("nav/times/{id}/{clube}")]
        public ActionResult ObterProdutosPorClube (string id, string clube)
        {
            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutosVitrine(linha: id);

            _model = new ProdutosViewModel { Produtos = produtos, Titulo = clube };

            return View("Navegacao", _model);
        }

        [Route("nav/genero/{id}/{genero}")]
        public ActionResult ObterProdutosPorGenero(string id, string genero)
        {
            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutosVitrine(genero: id);

            _model = new ProdutosViewModel { Produtos = produtos, Titulo = genero };

            return View("Navegacao", _model);
        }
    }
}