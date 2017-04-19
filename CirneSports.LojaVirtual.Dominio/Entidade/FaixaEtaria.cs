using System.ComponentModel.DataAnnotations;

namespace CirneSports.LojaVirtual.Dominio.Entidade
{
    public class FaixaEtaria
    {
        [Key]
        public int FaixaEtariaId { get; set; }

        public string FaixaEtariaCodigo { get; set; }

        public string FaixaEtariaDescricao { get; set; }
    }
}
