using System.ComponentModel.DataAnnotations;

namespace CirneSports.LojaVirtual.Dominio.Entidade
{
    public class SubGrupo
    {
        [Key]
        public int SubGrupoId { get; set; }

        public string GrupoCodigo { get; set; }

        public string SubGrupoCodigo { get; set; }

        public string SubGrupoDescricao { get; set; }
    }
}
