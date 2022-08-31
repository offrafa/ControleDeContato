using ControleDeContato.DAO;
using ControleDeContato.Models;
using ControleDeContato.Session;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ControleDeContato.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioDAO _usuarioDAO;
        private readonly ISessao _sessao;
        private readonly IEmailDAO _emailDAO;

        public LoginController(IUsuarioDAO usuarioDAO, 
                               ISessao sessao,
                               IEmailDAO emailDAO)
        {
            _usuarioDAO = usuarioDAO;
            _sessao = sessao;
            _emailDAO = emailDAO;
        }

        public IActionResult Index()
        {
            // Se o Uusario estiver logado, redireciona para home

            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");


            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioDAO.BuacaPorLogin(loginModel.Login);

                    if(usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoDoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = $"Senha do usuário invalida, Tente novamente mais tarde";
                    }

                    TempData["MensagemErro"] = $"Usuário/Senha invalido(s), Por favor tente mais tarde";
                    
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar o login, tente novamente mais tarde, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult EnviarLink(RedifinirSenhaModel redifinirSenha)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioDAO.BuscarPorEmailLogin(redifinirSenha.Email, redifinirSenha.Login);

                    if (usuario != null)
                    {
                        string novaSenha = usuario.GerarNovaSenha();
                        string mensagem = $"Sua nova senha é {novaSenha}";

                        bool emailEnviado = _emailDAO.Enviar(usuario.Email, "Sistema de Contato - Nova Senha", mensagem);

                        if (emailEnviado)
                        {
                            _usuarioDAO.Atualizar(usuario);
                            TempData["MensagemSucesso"] = $"Enviamos para seu email cadastrado uma nova senha.";
                        }
                        else
                        {
                            TempData["MensagemErro"] = $"Não conseguimos enviar e-mail, Tente mais tarde";

                        }

                        return RedirectToAction("Index", "Login");
                    }

                    TempData["MensagemErro"] = $"Não conseguimos redefinir sua senha, Tente mais tarde";

                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos redefinir sua senha, tente novamente mais tarde, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    

        public IActionResult RedefinirSenha()
        {
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessao();
            return RedirectToAction("Index", "Login");
        }
    }
}
