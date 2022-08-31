using ControleDeContato.DAO;
using ControleDeContato.Filtro;
using ControleDeContato.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ControleDeContato.Controllers
{
    [UsuarioLogado]
    public class ContatoController : Controller
    {
        private readonly IContatoDAO _ContatoDAO;
        public ContatoController(IContatoDAO contatoDAO)
        {
            _ContatoDAO = contatoDAO;
        }

        public IActionResult Index()
        {
            List<ContatoModel> Contatos = _ContatoDAO.BuscaTodos();

            return View(Contatos);
        }
        
        

        public IActionResult ApagarConfirma(int id)
        {
            ContatoModel contato = _ContatoDAO.ListarPorId(id);
            return View(contato);
        }
        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _ContatoDAO.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar seu contato";
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu contato, mais detalhe do erro {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Criar()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Criar(ContatoModel contato) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ContatoDAO.Adiciona(contato);
                    TempData["MensagemSucesso"] = "Contato Castrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch(System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu contato, tente novamente mais tarde, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _ContatoDAO.ListarPorId(id);
            return View(contato);
        }
        [HttpPost]
        public IActionResult Alterar(ContatoModel contato) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ContatoDAO.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato);
            } 
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu contato, tente novamente mais tarde, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
