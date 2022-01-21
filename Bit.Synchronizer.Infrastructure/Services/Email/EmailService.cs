using Bit.Subscription.Domain.Common.Interfaces.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Subscription.Infrastructure.Services.Email
{
    public class EmailService : IEmailService
    {

        public readonly EmailConfiguration _configuration;
        private SmtpClient Cliente { get; }

        public EmailService(EmailConfiguration configuration)
        {
            _configuration = configuration;
            Cliente = new SmtpClient()
            {
                Host = _configuration.Host,
                Port = _configuration.Port,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_configuration.Email, _configuration.Password),
                EnableSsl = _configuration.EnableSsl,
            };
        }

        /// <summary>
        /// Permite envio de emails
        /// </summary>
        /// <param name="email"></param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var correo = new MailMessage(from: _configuration.Email, to: email, subject: subject, body: message);
            correo.IsBodyHtml = true;
            return Cliente.SendMailAsync(correo);
        }
    }
}
