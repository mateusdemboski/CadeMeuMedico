using System;
using System.ComponentModel.DataAnnotations;

namespace CadeMeuMedico.Models
{
    public partial class Medicos
    {
        public long IDMedico { get; set; }

        [Required(ErrorMessage = "Obrigatório informar se atende por convênio")]
        public bool AtendePorConvenio { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o bairro")]
        [StringLength(60, ErrorMessage = "O bairro deve possuir no máximo 60 caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o CRM")]
        [StringLength(30, ErrorMessage = "O CRM deve possuir no máximo 30 caracteres")]
        public string CRM { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o e-mail")]
        [StringLength(100, ErrorMessage = "O e-mail deve possuir no máximo 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o endereço")]
        [StringLength(100, ErrorMessage = "O endereço deve possuir no máximo 100 caracteres")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a cidade")]
        public int IDCidade { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a especialidade")]
        public int IDEspecialidade { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o nome")]
        [StringLength(80, ErrorMessage = "O nome deve possuir no máximo 80 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar se tem clínica")]
        public bool TemClinica { get; set; }

        [StringLength(80, ErrorMessage = "O website ou blog deve possuir no máximo 80 caracteres")]
        public string WebsiteBlog { get; set; }

        public virtual Cidades IDCidadeNavigation { get; set; }

        public virtual Especialidades IDEspecialidadeNavigation { get; set; }
    }
}
