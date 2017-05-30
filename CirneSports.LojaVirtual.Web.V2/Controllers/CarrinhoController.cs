using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;
using CirneSports.LojaVirtual.Dominio.Entidade;
using CirneSports.LojaVirtual.Dominio.Repositorio;
using CirneSports.LojaVirtual.Web.V2.Models;
using System.Configuration;
using System.Collections.Generic;

namespace CirneSports.LojaVirtual.Web.V2.Controllers
{
    public class CarrinhoController : Controller
    {
        private CirneProdutosRepositorio _repositorio;
        private ClientesRepositorio _clienteRepositorio = new ClientesRepositorio();
        private PedidosRepositorio _pedidosRepositorio = new PedidosRepositorio();

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

            return RedirectToAction("Index", "Nav");
        }

        [Authorize]
        public ViewResult FecharPedido()
        {
            Pedido novoPedido = new Pedido();
            novoPedido.ClienteId = User.Identity.GetUserId();
            novoPedido.Cliente = _clienteRepositorio.ObterCliente(User.Identity.GetUserId());

            return View(novoPedido);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult FecharPedido(Carrinho carrinho, Pedido pedido)
        {

            if (!carrinho.ItensCarrinho.Any())
            {
                ModelState.AddModelError("", "Não foi possível concluir  o pedido, o Carrinho está vazio!");
            }

            if (ModelState.IsValid)
            {
                pedido.ProdutosPedido = new List<ProdutoPedido>();

                foreach(var item in carrinho.ItensCarrinho)
                { 
                    pedido.ProdutosPedido.Add(new ProdutoPedido()
                    {
                        Quantidade = item.Quantidade,
                        ProdutoId = item.Produto.ProdutoId
                    });
                }
                pedido.Pago = false;
                pedido = _pedidosRepositorio.SalvarPedido(pedido);

                return RedirectToAction("PedidoConcluido", new { pedidoId = pedido.Id });
            }
            else
            {
                return View(pedido);
            }
        }

        public ViewResult PedidoConcluido(Carrinho carrinho, int pedidoId)
        {

            EmailConfiguracoes email = new EmailConfiguracoes
            {
                EscreverArquivo = bool.Parse(ConfigurationManager.AppSettings["Email.EscreverArquivo"] ?? "false")
            };

            EmailPedido emailPedido = new EmailPedido(email);

            var pedido = _pedidosRepositorio.ObterPedido(pedidoId);

            emailPedido.ProcessarPedido(carrinho, pedido);
            carrinho.LimparCarrinho();

            return View(pedido);
        }
    }
}