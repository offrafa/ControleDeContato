using ControleDeContato.Models;
using System.Collections.Generic;

namespace ControleDeContato.DAO
{
    public interface IContatoDAO
    {
        ContatoModel ListarPorId(int id);

        List<ContatoModel> BuscaTodos();

        ContatoModel Adiciona(ContatoModel contato);

        ContatoModel Atualizar(ContatoModel contato);

        bool Apagar(int id);
    }
}
