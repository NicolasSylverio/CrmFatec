using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Crm.Application.ViewModels.AccountViewModels
{
    public class SignUpViewModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "E-mail não informado")]
        [MinLength(5, ErrorMessage = "O campo Nome deve ter no minimo 5 caracteres")]
        [MaxLength(100, ErrorMessage = "O campo Nome deve ter no maximo 100 caracteres")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("E-Mail")]
        public string Email { get; set; }

        [PasswordPropertyText]
        [Required(ErrorMessage = "Senha não infomada")]
        [MinLength(6, ErrorMessage = "O campo Nome deve ter no minimo 6 caracteres")]
        [MaxLength(16, ErrorMessage = "O campo Nome deve ter no maximo 16 caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Campo usuario obrigatorio")]
        [MinLength(6, ErrorMessage = "Campo usuario deve ter no minimo 6 caracteres")]
        [MaxLength(16, ErrorMessage = "Campo usuario deve ter no maximo 16 caracteres")]
        [DisplayName("Usuario")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Campo Cpf Obrigatorio")]
        [MinLength(11, ErrorMessage = "Campo Cpf deve ter no minimo 11 caracteres")]
        [MaxLength(11, ErrorMessage = "Campo Cpf deve ter no maximo 11 caracteres")]
        [DisplayName("Cpf")]
        public string Cpf { get; set; }
    }
}