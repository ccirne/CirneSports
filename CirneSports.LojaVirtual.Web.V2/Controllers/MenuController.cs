using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using CirneSports.LojaVirtual.Dominio.Repositorio;
using CirneSports.LojaVirtual.Web.V2.HtmlHelpers;

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

            var ClubesRepositorio = _repositorio.ObterClubesNacionais();

            var clubes = from n in ClubesRepositorio
                         select new
                         {
                             Clube = n.LinhaDescricao,
                             ClubeSeo = n.LinhaDescricao.ToSeoUrl(),
                             ClubeCodigo = n.LinhaCodigo
                         };

            return Json(clubes, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterClubesInternacionais()
        {
            _repositorio = new MenuRepositorio();

            var ClubesRepositorio = _repositorio.ObterClubesInternacionais();

            var clubes = from n in ClubesRepositorio
                         select new
                         {
                             Clube = n.LinhaDescricao,
                             ClubeSeo = n.LinhaDescricao.ToSeoUrl(),
                             ClubeCodigo = n.LinhaCodigo
                         };

            return Json(clubes, JsonRequestBehavior.AllowGet);
        }

        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterSelecoes()
        {
            _repositorio = new MenuRepositorio();

            var ClubesRepositorio = _repositorio.ObterSelecoes();

            var clubes = from n in ClubesRepositorio
                         select new
                         {
                             Clube = n.LinhaDescricao,
                             ClubeSeo = n.LinhaDescricao.ToSeoUrl(),
                             ClubeCodigo = n.LinhaCodigo
                         };

            return Json(clubes, JsonRequestBehavior.AllowGet);
        }
    }
}