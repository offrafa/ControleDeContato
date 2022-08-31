using ControleDeContato.Models;

namespace ControleDeContato.Session
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(UsuarioModel usuario);

        void RemoverSessao();

        UsuarioModel BuscarSessaoDoUsuario();
    }
}
