using Crm.Domain.Enum;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Crm.Application.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]        
        public int Id { get; set; }

        [Required(ErrorMessage = "O Campo Nome é Obrigatorio")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Números e caracteres especiais não são permitidos no nome.")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Nome deve ter no maximo 50 caracteres")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Campo Sobrenome é Obrigatorio")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Sobrenome deve ter no maximo 50 caracteres")]
        [DisplayName("Sobrenome")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O Campo Login é Obrigatorio")]
        [StringLength(maximumLength: 20, MinimumLength = 6, ErrorMessage = "Login deve ter no maximo 20 caracteres")]
        [DisplayName("Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O Campo Senha é Obrigatorio")]
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 20, MinimumLength = 2, ErrorMessage = "Celular deve ter no maximo 15 caracteres")]
        [DisplayName("Senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O Campo E-Mail é Obrigatorio")]
        [EmailAddress]
        [MaxLength(100, ErrorMessage = "O campo E-Mail deve ter menos que 100 caracteres")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Campo Cpf é Obrigatorio")]
        [StringLength(maximumLength:11, MinimumLength = 10, ErrorMessage = "Cpf deve ter no maximo 15 caracteres")]
        [DisplayName("Cpf")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O Campo Celular é Obrigatorio")]
        [StringLength(maximumLength: 15, MinimumLength = 8, ErrorMessage = "Celular deve ter no maximo 15 caracteres")]
        [DisplayName("Celular")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "O Campo Data Nascimento é Obrigatorio")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        
        [DisplayName("Tipo Permissão")]
        [EnumDataType(typeof(TipoUsuario))]
        public TipoUsuario TipoUsuario { get; set; }

        [DisplayName("Sexo")]
        [EnumDataType(typeof(TipoSexo))]
        public TipoSexo Sexo { get; set; }
    }
}