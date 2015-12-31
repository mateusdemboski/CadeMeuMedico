using System;
using System.ComponentModel.DataAnnotations;

namespace CadeMeuMedico.Models
{
    public partial class Medicos
    {
        public long IDMedico { get; set; }

        [Required(ErrorMessage = "Obrigat�rio informar se atende por conv�nio")]
        public bool AtendePorConvenio { get; set; }

        [Required(ErrorMessage = "Obrigat�rio informar o bairro")]
        [StringLength(60, ErrorMessage = "O bairro deve possuir no m�ximo 60 caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Obrigat�rio informar o CRM")]
        [StringLength(30, ErrorMessage = "O CRM deve possuir no m�ximo 30 caracteres")]
        public string CRM { get; set; }

        [Required(ErrorMessage = "Obrigat�rio informar o e-mail")]
        [StringLength(100, ErrorMessage = "O e-mail deve possuir no m�ximo 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigat�rio informar o endere�o")]
        [StringLength(100, ErrorMessage = "O endere�o deve possuir no m�ximo 100 caracteres")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Obrigat�rio informar a cidade")]
        public int IDCidade { get; set; }

        [Required(ErrorMessage = "Obrigat�rio informar a especialidade")]
        public int IDEspecialidade { get; set; }

        [Required(ErrorMessage = "Obrigat�rio informar o nome")]
        [StringLength(80, ErrorMessage = "O nome deve possuir no m�ximo 80 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigat�rio informar se tem cl�nica")]
        public bool TemClinica { get; set; }

        [StringLength(80, ErrorMessage = "O website ou blog deve possuir no m�ximo 80 caracteres")]
        public string WebsiteBlog { get; set; }

        public virtual Cidades IDCidadeNavigation { get; set; }

        public virtual Especialidades IDEspecialidadeNavigation { get; set; }
    }
}
