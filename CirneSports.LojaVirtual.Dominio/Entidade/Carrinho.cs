﻿using System.Collections.Generic;
using System.Linq;

namespace CirneSports.LojaVirtual.Dominio.Entidade
{
    public class Carrinho
    {
        private readonly List<ItemCarrinho> _itemCarrinho = new List<ItemCarrinho>();

        //Adicionar
        public void AdicionarItem(CirneProduto produto, int quantidade)
        {
            ItemCarrinho item = _itemCarrinho.FirstOrDefault(p => p.Produto.ProdutoId == produto.ProdutoId);

            if (item == null)
            {
                _itemCarrinho.Add(new ItemCarrinho
                {
                    Produto = produto,
                    Quantidade = quantidade
                });
            }
            else
            {
                item.Quantidade = quantidade;
            }
        }

        //Remover um item do carrinho
        public void RemoverItem(CirneProduto produto)
        {
            _itemCarrinho.RemoveAll(l => l.Produto.ProdutoId == produto.ProdutoId);
        }

        //Obter o valor total
        public decimal ObterValorTotal()
        {
            return _itemCarrinho.Sum(e => e.Produto.Preco * e.Quantidade);
        }

        //Limpar o carrinho
        public void LimparCarrinho()
        {
            _itemCarrinho.Clear();
        }

        public IEnumerable<ItemCarrinho> ItensCarrinho
        {
            get { return _itemCarrinho; }
            
        }
    }

    public class ItemCarrinho
    {
        public CirneProduto Produto { get; set; }

        public int Quantidade { get; set; }
    }
}
