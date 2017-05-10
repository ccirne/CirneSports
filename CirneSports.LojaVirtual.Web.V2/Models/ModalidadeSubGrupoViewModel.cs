using System.Collections.Generic;
using CirneSports.LojaVirtual.Dominio.Dto;
using CirneSports.LojaVirtual.Dominio.Entidade;

namespace CirneSports.LojaVirtual.Web.V2.Models
{
    public class ModalidadeSubGrupoViewModel
    {
        public Modalidade Modalidade { get; set; }

        public IEnumerable<SubGrupoDto> SubGrupos { get; set; }
    }
}