using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CadeMeuMedico.Models
{
    public partial class Especialidades
    {
        public Especialidades()
        {
            Medicos = new HashSet<Medicos>();
        }

        public int IDEspecialidade { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Nome")]
        [StringLength(80, ErrorMessage = "O Nome deve possuir no máximo 80 caracteres")]
        public string Nome { get; set; }

        public virtual ICollection<Medicos> Medicos { get; set; }
    }
}
