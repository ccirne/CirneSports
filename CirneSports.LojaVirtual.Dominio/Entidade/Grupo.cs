using System.ComponentModel.DataAnnotations;

namespace CirneSports.LojaVirtual.Dominio.Entidade
{
    public class Grupo
    {
        [Key]
        public int GrupoId { get; set; }

        public string GrupoCodigo { get; set; }

        public string GrupoDescricao { get; set; }
    }
}
