using ControleDeContato.Filtro;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContato.Controllers
{
    [UsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
