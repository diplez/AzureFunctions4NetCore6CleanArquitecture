using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Synchronizer.Infrastructure.Services.Email
{
    public class EmailConfiguration
    {
        public const string EmailConfig = "EmailSenderOptions";
        public int Port { get; set; }
        public string Password { get; set; }
        public bool EnableSsl { get; set; }
        public string Email { get; set; }
        public string Host { get; set; }
    }
}
