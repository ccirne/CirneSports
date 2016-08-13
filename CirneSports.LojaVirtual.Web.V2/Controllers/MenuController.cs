using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using CirneSports.LojaVirtual.Dominio.Repositorio;

namespace CirneSports.LojaVirtual.Web.V2.Controllers
{
    public class MenuController : Controller
    {
        private MenuRepositorio _repositorio;

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterEsportes()
        {
            _repositorio = new MenuRepositorio();

            var cat = _repositorio.ObterCategorias();

            var categoria = from c in cat
                            select new
                            {
                                c.CategoriaDescricao,
                                CategoriaDescricaoSeo = c.CategoriaDescricao.ToSeoUrl(),
                                c.CategoriaCodigo
                            };

            return Json(categoria, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterMarcas()
        {
            _repositorio = new MenuRepositorio();

            var listaMarcas = _repositorio.ObterMarcas();

            var marcas = from m in listaMarcas
                         select new
                         {
                             m.MarcaDescricao,
                             MarcaDescricaoSeo = m.MarcaDescricao.ToSeoUrl(),
                             m.MarcaCodigo
                         };

            return Json(marcas, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterClubesNacionais()
        {
            _repositorio = new MenuRepositorio();

            var listaClubesNacionais = _repositorio.ObterClubesNacionais();

            var clubesNacionais = from n in listaClubesNacionais
                         select new
                         {
                             n.LinhaDescricao,
                             LinhaDescricaoSeo = n.LinhaDescricao.ToSeoUrl(),
                             n.LinhaCodigo
                         };

            return Json(clubesNacionais, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterClubesInternacionais()
        {
            _repositorio = new MenuRepositorio();

            var listaClubesInternacionais = _repositorio.ObterClubesInternacionais();

            var clubesInternacionais = from i in listaClubesInternacionais
                                  select new
                                  {
                                      i.LinhaDescricao,
                                      LinhaDescricaoSeo = i.LinhaDescricao.ToSeoUrl(),
                                      i.LinhaCodigo
                                  };

            return Json(clubesInternacionais, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterSelecoes()
        {
            _repositorio = new MenuRepositorio();

            var listaSelecoes = _repositorio.ObterSelecoes();

            var selecoes = from s in listaSelecoes
                                       select new
                                       {
                                           s.LinhaDescricao,
                                           LinhaDescricaoSeo = s.LinhaDescricao.ToSeoUrl(),
                                           s.LinhaCodigo
                                       };

            return Json(selecoes, JsonRequestBehavior.AllowGet);
        }
    }
}