﻿using System.Linq;
using System.Web.Mvc;
using CirneSports.LojaVirtual.Dominio.Entidade;
using CirneSports.LojaVirtual.Dominio.Repositorio;
using CirneSports.LojaVirtual.Web.Models;

namespace CirneSports.LojaVirtual.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        private ProdutosRepositorio _repositorio;

        public RedirectToRouteResult Adicionar(int produtoId, string returnUrl)
        {
            _repositorio = new ProdutosRepositorio();

            Produto produto = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

            if (produto != null)
            {
                ObterCarrinho().AdicionarItem(produto, 1);
            }

            return RedirectToAction("Index", new{returnUrl});
        }

        private Carrinho ObterCarrinho()
        {
            Carrinho carrinho = (Carrinho) Session["Carrinho"];

            if (carrinho == null)
            {
                carrinho = new Carrinho();
                Session["Carrinho"] = carrinho;
            }

            return carrinho;
        }

        public RedirectToRouteResult Remover(int produtoId, string returnUrl)
        {
            _repositorio = new ProdutosRepositorio();

            Produto produto = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

            if (produto != null)
            {
                ObterCarrinho().RemoverItem(produto);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult Index(string returnurl)
        {
            return View(new CarrinhoViewModel
            {
                Carrinho = ObterCarrinho(),
                ReturnUrl = returnurl
            });
        }
    }
}