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

        [Route("nav/esportes/{id}/{esportes}")]
        public ActionResult ObterProdutosPorCategoria(string id, string esportes)
        {
            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutosVitrine(categoria: id);

            _model = new ProdutosViewModel { Produtos = produtos, Titulo = esportes };

            return View("Navegacao", _model);
        }

        [Route("nav/genero/{idgenero}/{genero}/{idgrupo}/{grupo}")]
        public ActionResult ObterProdutosCalcadosMasc(string idgenero, string genero, string idgrupo, string grupo)
        {
            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutosVitrine(genero: idgenero, grupo: idgrupo);

            _model = new ProdutosViewModel { Produtos = produtos, Titulo = grupo };

            return View("Navegacao", _model);
        }

        [Route("nav/genero/{idgenero}/{genero}/{idgrupo}/{grupo}/{idsubgrupo}/{subgrupo}")]
        public ActionResult ObterProdutosCalcadosMascChuteira(string idgenero, string genero, string idgrupo, string grupo, string idsubgrupo, string subgrupo)
        {
            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutosVitrine(genero: idgenero, grupo: idgrupo, subgrupo: idsubgrupo);

            _model = new ProdutosViewModel { Produtos = produtos, Titulo = grupo + " / " + subgrupo};

            return View("Navegacao", _model);
        }
    }
}