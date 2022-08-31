using ControleDeContato.Enum;
using ControleDeContato.Session;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContato.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o login do usuário")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o email do usuário")]
        [EmailAddress(ErrorMessage = "O E-mail informado não é valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o perfil do usuário")]
        public PerfilEnum Perfil { get; set; }

        [Required(ErrorMessage = "Digite a senha do usuário")]
        public string Senha { get; set; }

        public DateTime DataDeCadastro { get; set; }

        public DateTime? DataDeAtualizacao { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha.GerarHash();
        }

        public void SenhaHash()
        {
            Senha = Senha.GerarHash();
        }

        public string GerarNovaSenha()
        {
            string NovaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = NovaSenha.GerarHash();
            return NovaSenha;
        }
    }
}
