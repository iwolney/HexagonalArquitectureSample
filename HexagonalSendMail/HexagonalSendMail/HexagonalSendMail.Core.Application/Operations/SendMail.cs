using HexagonalSendMail.Core.Application.Interfaces;
using System.Net;
using System.Net.Mail;

namespace HexagonalSendMail.Core.Application.Operations
{
    public class SendMail : ISendMail
    {
        private readonly string smtpHost = "smtp.mailcorp.com.br";
        private readonly int smtpPort = 465;
        private readonly string smtpAccount = "inforshop@inforshop.com.br";
        private readonly string smtpPass = "General@7592";

        public SendMail() { }

        public async Task SenderMail(MailMessage mail)
        {
            mail.From = new MailAddress(smtpAccount);

            SmtpClient? smtpClient = new(smtpHost)
            {
                Host = smtpHost,
                Port = smtpPort,
                EnableSsl = true,
                Credentials = new NetworkCredential(smtpAccount, smtpPass),
                UseDefaultCredentials = false
            };

            try
            {
                smtpClient.Send(mail);
                Console.WriteLine("Status: E-mail Enviado!");
                smtpClient = null;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
