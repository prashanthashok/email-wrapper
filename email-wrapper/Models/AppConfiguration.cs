using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace email_wrapper.Models
{
    public class AppConfiguration
    {
        public EmailProviderEnum EmailProvider { get; set; }
    }

    public enum EmailProviderEnum
    {
        MailGun,
        SendGrid
    }
}
