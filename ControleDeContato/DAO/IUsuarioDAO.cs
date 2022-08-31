using ControleDeContato.Models;
using System.Collections.Generic;

namespace ControleDeContato.DAO
{
    public interface IUsuarioDAO
    {
        UsuarioModel BuacaPorLogin(string login);

        UsuarioModel BuscarPorEmailLogin(string email, string login);

        UsuarioModel ListarPorId(int id);

        List<UsuarioModel> BuscaTodos();

        UsuarioModel Adiciona(UsuarioModel usuario);

        UsuarioModel Atualizar(UsuarioModel usuario);

        bool Apagar(int id);
    }
}
