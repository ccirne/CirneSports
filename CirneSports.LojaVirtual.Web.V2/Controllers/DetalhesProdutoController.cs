using System.Web.Mvc;
using CirneSports.LojaVirtual.Web.V2.Models;
using CirneSports.LojaVirtual.Dominio.Repositorio;
using AutoMapper;

namespace CirneSports.LojaVirtual.Web.V2.Controllers
{
    [RoutePrefix("produto")]
    public class DetalhesProdutoController : Controller
    {
        [Route("{codigo}/{marca}/{produto}/{corcodigo}")]
        public ActionResult Detalhes(string codigo, string corCodigo)
        {
            var repositorio = new DetalhesProdutoRepositorio();
            var produto = repositorio.ObterProdutoModelo(codigo, corCodigo);
            var model = Mapper.DynamicMap<DetalhesProdutoViewModel>(produto);
            model.CoresList = new SelectList(produto.Cores, "CorCodigo", "CorDescricao", corCodigo);
            model.TamanhoList = new SelectList(produto.Tamanhos, "TamanhoCodigo", "TamanhoDescricaoResumida");
            model.Breadcrumb = repositorio.ObterBreadCrumb(produto.Produto.ProdutoModeloCodigo);
            return View(model);
        }
    }
}