using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CadeMeuMedico.Models
{
    public partial class Usuarios
    {

        public long IDUsuario { get; set; }

        [Required(ErrorMessage = "Obrigat�rio informar o E-mail")]
        [StringLength(100, ErrorMessage = "O E-mail deve possuir no m�ximo 80 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigat�rio informar o Login")]
        [StringLength(30, ErrorMessage = "O Login deve possuir no m�ximo 80 caracteres")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Obrigat�rio informar o Nome")]
        [StringLength(80, ErrorMessage = "O Nome deve possuir no m�ximo 80 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigat�rio informar a Senha")]
        [StringLength(100, ErrorMessage = "A Senha deve possuir no m�ximo 100 caracteres")]
        public string Senha { get; set; }
    }
}
