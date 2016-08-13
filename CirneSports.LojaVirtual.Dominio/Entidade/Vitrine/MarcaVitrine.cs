using System.ComponentModel.DataAnnotations;

namespace CirneSports.LojaVirtual.Dominio.Entidade.Vitrine
{
    public class MarcaVitrine
    {
        [Key]
        public string MarcaCodigo { get; set; }

        public string MarcaDescricao { get; set; }

        public int MarcaId { get; set; }
    }
}
