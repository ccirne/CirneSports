using System.Linq;
using System.Web.Mvc;
using CirneSports.LojaVirtual.Dominio.Entidade;
using CirneSports.LojaVirtual.Dominio.Repositorio;
using CirneSports.LojaVirtual.Web.V2.Models;
using System.Configuration;

namespace CirneSports.LojaVirtual.Web.V2.Controllers
{
    public class CarrinhoController : Controller
    {
        private CirneProdutosRepositorio _repositorio;

        public ViewResult Index(Carrinho carrinho, string returnurl)
        {
            return View(new CarrinhoViewModel
            {
                Carrinho = carrinho,
                ReturnUrl = returnurl
            });
        }

        public PartialViewResult Resumo(Carrinho carrinho)
        {
             return PartialView(carrinho);
        }


        public RedirectToRouteResult Adicionar(Carrinho carrinho, int quantidade,
            string produto, string Cor, string Tamanho, string returnUrl)
        {
            _repositorio = new CirneProdutosRepositorio();

            CirneProduto prod = _repositorio.ObterProduto(produto, Cor, Tamanho);

            if (produto != null)
            {
                carrinho.AdicionarItem(prod, quantidade);
            }

            return RedirectToAction("Index", "Nav");
        }

        public RedirectToRouteResult Remover(Carrinho carrinho, int produtoId, string returnUrl)
        {
            _repositorio = new CirneProdutosRepositorio();

            CirneProduto produto = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

            if (produto != null)
            {
                carrinho.RemoverItem(produto);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult FecharPedido()
        {
            return View(new Pedido());
        }

        [HttpPost]
        public ViewResult FecharPedido(Carrinho carrinho, Pedido pedido)
        {

            EmailConfiguracoes email = new EmailConfiguracoes
            {
                EscreverArquivo = bool.Parse(ConfigurationManager.AppSettings["Email.EscreverArquivo"] ?? "false")
            };

            EmailPedido emailPedido = new EmailPedido(email);

            if (!carrinho.ItensCarrinho.Any())
            {
                ModelState.AddModelError("", "Não foi possível concluir  o pedido, o Carrinho está vazio!");
            }

            if (ModelState.IsValid)
            {
                emailPedido.ProcessarPedido(carrinho, pedido);
                carrinho.LimparCarrinho();
                return View("PedidoConcluido");
            }
            else
            {
                return View(pedido);
            }
        }

        public ViewResult PedidoConcluido()
        {
            return View();
        }
    }
}