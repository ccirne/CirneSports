using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CirneSports.LojaVirtual.Dominio.Entidade;

namespace CirneSports.LojaVirtual.Dominio.Repositorio
{
    public class CirneProdutosRepositorio
    {

        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<CirneProduto> Produtos
        {
            get { return _context.CirneProduto; }
        }


        public CirneProduto ObterProduto(string codigo, string corCodigo, string tamanhoCodigo)
        {
            return _context.CirneProduto.Single(p => p.ProdutoModeloCodigo == codigo
                    && p.CorCodigo == corCodigo && p.TamanhoCodigo == tamanhoCodigo);
        }

        //Salvar Produto - Alterar Produto
        public void Salvar(CirneProduto produto)
        {
            if (produto.ProdutoId == 0)
            {
                //Salvado
                _context.CirneProduto.Add(produto);
            }
            else
            {
                //Alteração
                _context.Entry(produto).State = System.Data.Entity.EntityState.Modified;
            }

            _context.SaveChanges();
        }


        //Excluir

        public CirneProduto Excluir(int produtoId)
        {

            CirneProduto prod = _context.CirneProduto.Find(produtoId);

            if (prod != null)
            {
                _context.CirneProduto.Remove(prod);
                _context.SaveChanges();
            }

            return prod;
        }
    }
}
