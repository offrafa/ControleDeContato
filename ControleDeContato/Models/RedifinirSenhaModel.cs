using System.ComponentModel.DataAnnotations;

namespace ControleDeContato.Models
{
    public class RedifinirSenhaModel
    {
        [Required(ErrorMessage = "Digite o login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o email do usuário")]
        [EmailAddress(ErrorMessage = "O E-mail informado não é valido")]
        public string Email { get; set; }
    }
}
