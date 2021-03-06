﻿using System.Linq;
using System.Web.Mvc;
using CirneSports.LojaVirtual.Dominio.Repositorio;
using CirneSports.LojaVirtual.Dominio.Entidade;
using CirneSports.LojaVirtual.Web.Models;
using System;

namespace CirneSports.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutosRepositorio _repositorio;
        public int ProdutosPorPagina = 12;

        //public ViewResult ListaProdutos(string categoria, int pagina = 1)
        //{
        //    _repositorio = new ProdutosRepositorio();

        //    ProdutosViewModel model = new ProdutosViewModel
        //    {

        //        Produtos = _repositorio.Produtos
        //            .Where(p => categoria == null || p.Categoria == categoria)
        //            .OrderBy(p => p.Descricao)
        //            .Skip((pagina - 1) * ProdutosPorPagina)
        //            .Take(ProdutosPorPagina),

        //        Paginacao = new Paginacao
        //        {
        //            PaginaAtual = pagina,
        //            ItensPorPagina = ProdutosPorPagina,
        //            ItensTotal = categoria == null ? _repositorio.Produtos.Count() : _repositorio.Produtos.Count(e => e.Categoria == categoria)
        //        },

        //        CategoriaAtual = categoria

        //    };

        //    return View(model);
        //}

        [Route("DetalhesProduto/{id}/{produto}")]
        public ViewResult Detalhes(int id)
        {
            _repositorio = new ProdutosRepositorio();
            Produto produto = _repositorio.ObterProduto(id);
            return View(produto);
        }


        public ViewResult ListaProdutos(string categoria)
        {
            _repositorio = new ProdutosRepositorio();

            var model = new ProdutosViewModel();

            var random = new Random();

            if (categoria != null)
            {
                model.Produtos = _repositorio.Produtos
                    .Where(p => p.Categoria == categoria)
                    .OrderBy(x => random.Next()).ToList();
            }
            else
            {
                model.Produtos = _repositorio.Produtos
                    .OrderBy(x => random.Next())
                    .Take(ProdutosPorPagina).ToList();
            }
            
            return View(model);
        }


        [Route("Vitrine/ObterImagem/{produtoId}")]
        public FileContentResult ObterImagem(int produtoId)
        {
            _repositorio = new ProdutosRepositorio();
            Produto prod = _repositorio.Produtos
                .FirstOrDefault(p => p.ProdutoId == produtoId);

            if (prod != null)
            {
                return File(prod.Imagem, prod.ImagemMimeType);
            }

            return null;
        }
    }
}