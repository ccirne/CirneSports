using System.Collections.Generic;
using CirneSports.LojaVirtual.Dominio.Entidade;
using CirneSports.LojaVirtual.Dominio.Dto;
using System.Web.Mvc;

namespace CirneSports.LojaVirtual.Web.V2.Models
{
    public class DetalhesProdutoViewModel
    {
        public CirneProduto Produto { get; set; }
        public IEnumerable<Cor> Cores { get; set; }
        public IEnumerable<Tamanho> Tamanhos { get; set; }
        public BreadCrumbDto Breadcrumb { get; set; }
        public SelectList CoresList { get; set; }
        public SelectList TamanhoList { get; set; }
    }
}