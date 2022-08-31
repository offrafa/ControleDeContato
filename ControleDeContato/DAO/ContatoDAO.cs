using ControleDeContato.Data;
using ControleDeContato.Models;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeContato.DAO
{
    public class ContatoDAO : IContatoDAO
    {
        private readonly BancoContext _BancoContext;
        public ContatoDAO(BancoContext bancoContext)
        {
            _BancoContext = bancoContext;
        }
        public ContatoModel ListarPorId(int id)
        {
            return _BancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public List<ContatoModel> BuscaTodos()
        {
            return _BancoContext.Contatos.ToList();
        }

        public ContatoModel Adiciona(ContatoModel contato)
        {
            //Gravar No Banco De Dados        
            _BancoContext.Contatos.Add(contato);
            _BancoContext.SaveChanges();
            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarPorId(contato.Id);

            if (contatoDB == null) throw new System.Exception("Houve um erro na aualização do contato!");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _BancoContext.Contatos.Update(contatoDB);
            _BancoContext.SaveChanges();

            return contatoDB;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListarPorId(id);

            if (contatoDB == null) throw new System.Exception("Houve um erro exclusão do contato!");

            _BancoContext.Contatos.Remove(contatoDB);
            _BancoContext.SaveChanges();
            return true;

        }
    }
}
