using HexagonalSendMail.Core.Application.Interfaces;
using System.Net.Mail;

namespace HexagonalSendMail.Ports.SendMailWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ISendMail _sendMail;

        public Worker(ILogger<Worker> logger, ISendMail sendMail)
        {
            _logger = logger;
            _sendMail = sendMail;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                    var mail = new MailMessage
                    {
                        Subject = "Teste"
                    };
                    mail.To.Add("wolney.design@gmail.com");
                    mail.Body = string.Empty;
                    mail.IsBodyHtml = true;

                    await _sendMail.SenderMail(mail);
                }
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
