using System;
using System.ComponentModel.DataAnnotations;

namespace CirneSports.LojaVirtual.Dominio.Entidade
{
    public class Administrador
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage="Digite seu Login.")]
        [Display(Name="Login")]
        public string Login { get; set; }

        [Required(ErrorMessage="Digite sua Senha.")]
        [Display(Name="Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public DateTime UltimoAcesso { get; set; }
    }
}
