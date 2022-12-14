using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace ControleDeContato.DAO
{
    public class EmailDAO : IEmailDAO
    {
        private readonly IConfiguration _configuration;
        public EmailDAO(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Enviar(string email, string assunto, string mensagem)
        {
            try
            {
                string host = _configuration.GetValue<string>("SMTP:Host");
                string nome = _configuration.GetValue<string>("SMTP:Nome");
                string username = _configuration.GetValue<string>("SMTP:UserName");
                string senha = _configuration.GetValue<string>("SMTP:Senha");
                int porta = _configuration.GetValue<int>("SMTP:587");

                MailMessage mail = new MailMessage() 
                { 
                    From = new MailAddress(username, nome)
                };

                mail.To.Add(email);
                mail.Subject = mensagem;
                mail.Body = email;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                using (SmtpClient smtp = new SmtpClient(host, porta))
                {
                    smtp.Credentials = new NetworkCredential(username, senha);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }
    }
}
