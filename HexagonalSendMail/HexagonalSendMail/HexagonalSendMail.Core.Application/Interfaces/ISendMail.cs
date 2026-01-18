using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSendMail.Core.Application.Interfaces
{
    public interface ISendMail
    {
        Task SenderMail(MailMessage mail);
    }
}
