using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CirneSports.LojaVirtual.Dominio.Entidade;

namespace CirneSports.LojaVirtual.Web.V2.Models
{
    public class SubGrupoCategoriasViewModel
    {
        public SubGrupo SubGrupo { get; set; }

        public IEnumerable<Categoria> Categorias { get; set; }
    }
}