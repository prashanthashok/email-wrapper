using email_wrapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace email_wrapper.Contracts
{
    public interface IEmailHelper
    {
        Task<SendEmailResponse> SendEmail(HttpClient client, EmailRequest emailRequest);
    }
}
