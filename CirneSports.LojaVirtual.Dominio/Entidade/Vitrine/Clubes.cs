using System.ComponentModel.DataAnnotations;

namespace CirneSports.LojaVirtual.Dominio.Entidade.Vitrine
{
    public abstract class Clubes
    {
        [Key]
        public string LinhaCodigo { get; set; }

        public string LinhaDescricao { get; set; }

    }
}
