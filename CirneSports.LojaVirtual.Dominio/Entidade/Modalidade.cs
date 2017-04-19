using System.ComponentModel.DataAnnotations;

namespace CirneSports.LojaVirtual.Dominio.Entidade
{
    public class Modalidade
    {
        [Key]
        public int ModalidadeId { get; set; }

        public string ModalidadeCodigo { get; set; }

        public string ModalidadeDescricao { get; set; }
    }
}
