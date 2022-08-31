using ControleDeContato.DAO;
using ControleDeContato.Filtro;
using ControleDeContato.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ControleDeContato.Controllers
{
    [UsuarioAdmin]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioDAO _usuarioDAO;
        public UsuarioController(IUsuarioDAO usuarioDAO)
        {
            _usuarioDAO = usuarioDAO;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioDAO.BuscaTodos();

            return View(usuarios);
        }
        public IActionResult Criar()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioDAO.Adiciona(usuario);
                    TempData["MensagemSucesso"] = "Usuário Castrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu usuário, tente novamente mais tarde, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }


        public IActionResult ApagarConfirma(int id)
        {
            UsuarioModel usuario = _usuarioDAO.ListarPorId(id);
            return View(usuario);
        }
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _usuarioDAO.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Usuário apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar seu usuário";
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu usuário, mais detalhe do erro {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioDAO.ListarPorId(id);
            return View(usuario);
        }
        [HttpPost]
        public IActionResult Alterar(UsuarioSemSenhaModel usuarioSemSenha)
        {
            try
            {
                UsuarioModel usuario = null;


                if (ModelState.IsValid)
                {
                    usuario = new UsuarioModel()
                    {
                        Id = usuarioSemSenha.Id,
                        Nome = usuarioSemSenha.Nome,
                        Login = usuarioSemSenha.Login,
                        Email = usuarioSemSenha.Email,
                        Perfil = usuarioSemSenha.Perfil
                    };



                    usuario = _usuarioDAO.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu usuário, tente novamente mais tarde, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
