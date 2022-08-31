namespace ControleDeContato.DAO
{
    public interface IEmailDAO
    {
        bool Enviar(string email, string assunto, string mensagem);
    }
}
