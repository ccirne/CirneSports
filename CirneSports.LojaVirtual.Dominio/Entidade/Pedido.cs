using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CirneSports.LojaVirtual.Dominio.Entidade
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        public string ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<ProdutoPedido> ProdutosPedido { get; set; }

        public bool EmbrulhaPresente { get; set; }

        public bool Pago { get; set; }
    }
}
