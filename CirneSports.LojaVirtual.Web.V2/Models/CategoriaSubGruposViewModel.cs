using System.Collections.Generic;
using CirneSports.LojaVirtual.Dominio.Entidade;

namespace CirneSports.LojaVirtual.Web.V2.Models
{
    public class CategoriaSubGruposViewModel
    {
        public Categoria Categoria { get; set; }

        public IEnumerable<SubGrupo> SubGrupos { get; set; }
    }
}