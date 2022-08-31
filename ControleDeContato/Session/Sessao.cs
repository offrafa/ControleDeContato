using ControleDeContato.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ControleDeContato.Session
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _HttpContext;
        public Sessao(IHttpContextAccessor httpContext)
        {
            _HttpContext = httpContext;
        }

        public UsuarioModel BuscarSessaoDoUsuario()
        {
            string sessaoUsuario = _HttpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;
            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
        }

        public void CriarSessaoDoUsuario(UsuarioModel usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);
            _HttpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoverSessao()
        {
            _HttpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
