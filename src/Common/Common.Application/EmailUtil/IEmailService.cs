using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Application.EmailUtil
{

    public interface IEmailService
    {
        Task SendEmail(SendEmailRequest request);
    }

    public class SendEmailRequest
    {
        public SendEmailRequest(string to, string message, string subject)
        {
            To = to;
            Message = message;
            Subject = subject;
        }
        public string To { get; private set; }
        public string Message { get; private set; }
        public string Subject { get; private set; }
    }
}
