using CirneSports.LojaVirtual.Dominio.Entidade;

namespace CirneSports.LojaVirtual.Web.V2.Models
{
    public class CarrinhoViewModel
    {
        public Carrinho Carrinho { get; set; }

        public string ReturnUrl { get; set; }
    }
}