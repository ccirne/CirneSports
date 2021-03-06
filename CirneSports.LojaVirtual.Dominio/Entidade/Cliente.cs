﻿using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace CirneSports.LojaVirtual.Dominio.Entidade
{
    public class Cliente : IdentityUser
    {
        [NotMapped]
        [DataType(DataType.Password)] 
        public string Senha { get; set; }

        [Required]
        public string NomeCompleto { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }

        // Telefone
        [Required]
        public virtual TelefoneCliente Telefone { get; set; }

        // Documento
        [Required]
        public virtual DocumentoCliente Documento { get; set; }

        // Endereço
        [Required]
        public virtual EnderecoCliente Endereco { get; set; }
    }
}
