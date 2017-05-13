using System.ComponentModel.DataAnnotations;

namespace CirneSports.LojaVirtual.Dominio.Entidade
{
    public class Tamanho
    {
        [Key]
        public int TamanhoId { get; set; }
        public string TamanhoCodigo { get; set; }
        public string TamanhoDescricaoResumida { get; set; }
        public string TamanhoDescricao { get; set; }
    }
}
