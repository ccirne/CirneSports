using System.ComponentModel.DataAnnotations;

namespace CirneSports.LojaVirtual.Dominio.Entidade
{
    public class Genero
    {
        [Key]
        public int GeneroId { get; set; }

        public string GeneroCodigo { get; set; }

        public string GeneroDescricao { get; set; }
    }
}
