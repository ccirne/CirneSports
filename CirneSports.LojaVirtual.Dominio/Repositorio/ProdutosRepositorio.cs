using System.Collections.Generic;
using CirneSports.LojaVirtual.Dominio.Entidade;

namespace CirneSports.LojaVirtual.Dominio.Repositorio
{
    public class ProdutosRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Produto> Produtos
        {
            get { return _context.Produtos; }
        }

        //Salvar produto - Alterar produto
        public void Salvar(Produto produto)
        {
            if (produto.ProdutoId == 0)
            {
                //Salvando
                _context.Produtos.Add(produto);
            }
            else
            {
                //Alterando
                Produto prod = _context.Produtos.Find(produto.ProdutoId);

                if (prod != null)
                {
                    prod.Nome = produto.Nome;
                    prod.Descricao = produto.Descricao;
                    prod.Preco = produto.Preco;
                    prod.Categoria = produto.Categoria;

                }
            }

            _context.SaveChanges();
        }


    }
}
