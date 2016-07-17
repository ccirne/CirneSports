using System;
using CirneSports.LojaVirtual.Dominio.Entidade;
using CirneSports.LojaVirtual.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Web.Mvc;
using CirneSports.LojaVirtual.Web.Models;

namespace CirneSports.LojaVirtual.UnitTest
{
    [TestClass]
    public class CarrinhoControllerTestes
    {
        [TestMethod]
        public void AdicionarItemAoCarrinho()
        {
            //Preparação (Arrange) e o estímulo (Act), das verificações (Asserts)
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste1"
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste2"
            };

            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 3);

            carrinho.AdicionarItem(produto2, 4);

            CarrinhoController controller = new CarrinhoController();

            //Act
            controller.Adicionar(carrinho, 2, "");

            //Assert
            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 2);

            Assert.AreEqual(carrinho.ItensCarrinho.ToArray()[0].Produto.ProdutoId, 1);
        }

        [TestMethod]
        public void Adiciono_produto_No_Carrinho_Volta_Para_A_Categoria()
        {
            //Arrenge
            Carrinho carrinho = new Carrinho();

            CarrinhoController controller = new CarrinhoController();

            //Act
            RedirectToRouteResult result = controller.Adicionar(carrinho, 2, "minhaUrl");

            //Assert
            Assert.AreEqual(result.RouteValues["action"], "Index");

            Assert.AreEqual(result.RouteValues["returnUrl"], "minhaUrl");
        }

        [TestMethod]
        public void Posso_Ver_O_Conteudo_Do_Carrinho()
        {
            //Arrenge
            Carrinho carrinho = new Carrinho();

            CarrinhoController controller = new CarrinhoController();

            //Act
            CarrinhoViewModel resultado = (CarrinhoViewModel)controller.Index(carrinho, "minhaUrl").ViewData.Model;

            //Assert
            Assert.AreSame(resultado.Carrinho, carrinho);

            Assert.AreEqual(resultado.ReturnUrl, "minhaUrl");
        }
    }
}
