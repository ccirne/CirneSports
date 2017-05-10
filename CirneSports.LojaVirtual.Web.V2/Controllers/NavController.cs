using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CirneSports.LojaVirtual.Web.V2.Models;
using CirneSports.LojaVirtual.Dominio.Repositorio;
using CirneSports.LojaVirtual.Web.V2.HtmlHelpers;

namespace CirneSports.LojaVirtual.Web.V2.Controllers
{
    public class NavController : Controller
    {
        private ProdutoModeloRepositorio _repositorio;
        private ProdutosViewModel _model;
        private MenuRepositorio _menu;

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

        [Route("nav/calcados/{idgrupo}/{grupo}")]
        public ActionResult ObterProdutosCalcados(string idgrupo, string grupo)
        {
            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutosVitrine(grupo: idgrupo);

            _model = new ProdutosViewModel { Produtos = produtos, Titulo = grupo };

            return View("Navegacao", _model);
        }

        [Route("nav/marcas/{idgrupo}/{grupo}/{idmarca}/{marca}")]
        public ActionResult ObterProdutosCalcadosMarcas(string idgrupo, string grupo, string idmarca, string marca)
        {
            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutosVitrine(grupo: idgrupo, marca: idmarca);

            _model = new ProdutosViewModel { Produtos = produtos, Titulo = grupo + " / " + marca };

            return View("Navegacao", _model);
        }

        [Route("nav/esportes/{idgrupo}/{grupo}/{idsubgrupo}/{subgrupo}")]
        public ActionResult ObterProdutosCalcadosEsportes(string idgrupo, string grupo, string idsubgrupo, string subgrupo)
        {
            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutosVitrine(grupo: idgrupo, subgrupo: idsubgrupo);

            _model = new ProdutosViewModel { Produtos = produtos, Titulo = grupo + " / " + subgrupo };

            return View("Navegacao", _model);
        }

        [Route("nav/vestuario/{idgrupo}/{grupo}")]
        public ActionResult ObterProdutosCalcadosEsportes(string idgrupo, string grupo)
        {
            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutosVitrine(grupo: idgrupo);

            _model = new ProdutosViewModel { Produtos = produtos, Titulo = grupo };

            return View("Navegacao", _model);
        }


        [ChildActionOnly]
        [OutputCache(Duration = 3600, VaryByParam = "*")]
        public ActionResult TenisCategoria()
        {
            _menu = new MenuRepositorio();
            var categorias = _menu.ObterTenisCategotia();
            var subgrupo = _menu.ObterSubGruposTenis();

            SubGrupoCategoriasViewModel model = new SubGrupoCategoriasViewModel
            {
                Categorias = categorias,
                SubGrupo = subgrupo
            };

            return PartialView("_TenisCategoria", model);
        }

        [Route("calcados/{SubGrupoCodigo}/tenis/{CategoriaCodigo}/{CategoriaDescricao}")]
        public ActionResult ObterTenisPorCategoria(string SubGrupoCodigo, string CategoriaCodigo, string CategoriaDescricao)
        {
            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutosVitrine(CategoriaCodigo, subgrupo: SubGrupoCodigo);
            _model = new ProdutosViewModel { Produtos = produtos, Titulo = CategoriaDescricao.UpperCaseFirst() };
            return View("Navegacao", _model);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600, VaryByParam = "*")]
        public ActionResult CasualSubGrupo()
        {
            _menu = new MenuRepositorio();
            var casual = _menu.ObterModalidadeCasual();
            var subGrupo = _menu.ObterCasualSubGrupo();

            var model = new ModalidadeSubGrupoViewModel
            {
                Modalidade = casual,
                SubGrupos = subGrupo

            };

            return PartialView("_CasualSubGrupo", model);
        }

        [Route("{modalidadeCodigo}/casual/{subGrupoCodigo}/{subGrupoDescricao}")]
        public ActionResult ObterModalidadeSubGrupo(string modalidadeCodigo, string subGrupoCodigo, string subGrupoDescricao)
        {
            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutosVitrine(modalidade: modalidadeCodigo, subgrupo: subGrupoCodigo);

            _model = new ProdutosViewModel
            {
                Produtos = produtos,
                Titulo = subGrupoDescricao.UpperCaseFirst()
            };

            return View("Navegacao", _model);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 3600, VaryByParam = "*")]
        public ActionResult Suplementos()
        {
            _menu = new MenuRepositorio();
            //var categoria = _menu.Suplemento();
            //var subGrupos = _menu.ObterSuplementos();


            //CategoriaSubGruposViewModel model = new CategoriaSubGruposViewModel
            //{
            //    Categoria = categoria,
            //    SubGrupos = subGrupos,

            //};
            //return PartialView("_Suplementos", model);
            return PartialView("_Suplementos");
        }

        [Route("{categoriaCodigo}/suplementos/{subGrupoCodigo}/{subGrupoDescricao}")]
        public ActionResult ObterCategoriaSubGrupos(string categoriaCodigo, string subGrupoCodigo, string subGrupoDescricao)
        {
            _repositorio = new ProdutoModeloRepositorio();
            var produtos = _repositorio.ObterProdutosVitrine(categoriaCodigo, subgrupo: subGrupoCodigo);
            _model = new ProdutosViewModel { Produtos = produtos, Titulo = subGrupoDescricao.UpperCaseFirst() };
            return View("Navegacao", _model);

        }
    }
}