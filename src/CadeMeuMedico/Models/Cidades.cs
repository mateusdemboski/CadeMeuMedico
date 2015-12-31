using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CadeMeuMedico.Models
{
    public partial class Cidades
    {
        public Cidades()
        {
            Medicos = new HashSet<Medicos>();
        }

        public int IDCidade { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Nome")]
        [StringLength(100, ErrorMessage = "O Nome deve possuir no máximo 100 caracteres")]
        public string Nome { get; set; }

        public virtual ICollection<Medicos> Medicos { get; set; }
    }
}
