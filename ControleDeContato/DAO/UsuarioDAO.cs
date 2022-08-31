using ControleDeContato.Data;
using ControleDeContato.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeContato.DAO
{
    public class UsuarioDAO : IUsuarioDAO
    {
        private readonly BancoContext _BancoContext;
        public UsuarioDAO(BancoContext bancoContext)
        {
            _BancoContext = bancoContext;
        }
        public UsuarioModel BuacaPorLogin(string login)
        {
            return _BancoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public UsuarioModel BuscarPorEmailLogin(string email, string login)
        {
            return _BancoContext.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
        }

        public UsuarioModel ListarPorId(int id)
        {
            return _BancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public List<UsuarioModel> BuscaTodos()
        {
            return _BancoContext.Usuarios.ToList();
        }

        public UsuarioModel Adiciona(UsuarioModel usuario)
        {
            //Gravar No Banco De Dados
            usuario.DataDeCadastro = DateTime.Now;
            usuario.SenhaHash();
            _BancoContext.Usuarios.Add(usuario);
            _BancoContext.SaveChanges();
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = ListarPorId(usuario.Id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na aualização do usuario!");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Email = usuario.Email; 
            usuarioDB.Perfil = usuario.Perfil;
            usuarioDB.DataDeAtualizacao = DateTime.Now;

            _BancoContext.Usuarios.Update(usuarioDB);
            _BancoContext.SaveChanges();

            return usuarioDB;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = ListarPorId(id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro exclusão do usuario!");

            _BancoContext.Usuarios.Remove(usuarioDB);
            _BancoContext.SaveChanges();
            return true;

        }

    }
}
