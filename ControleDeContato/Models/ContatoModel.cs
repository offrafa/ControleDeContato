using System.ComponentModel.DataAnnotations;

namespace ControleDeContato.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o Nome do contato")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "O E-mail informado não é valido!")]
        [Required(ErrorMessage = "Digite o E-mail do contato")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o Celular do contato")]
        [Phone(ErrorMessage = "O celular informado não é valido!")]
        public string Celular { get; set; }
    }
}
