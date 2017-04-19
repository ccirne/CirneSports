using System.Collections.Generic;
using CirneSports.LojaVirtual.Dominio.Entidade.Vitrine;

namespace CirneSports.LojaVirtual.Web.V2.Models
{
    public class ProdutosViewModel
    {
        public List<ProdutoVitrine> Produtos { get; set; }


        public string Titulo { get; set; }
    }
}