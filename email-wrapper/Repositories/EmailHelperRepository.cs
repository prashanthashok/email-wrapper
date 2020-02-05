using email_wrapper.Contracts;
using email_wrapper.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace email_wrapper.Repositories
{
    public class EmailHelperRepository: IEmailHelperRepository
    {
        private readonly Func<EmailProviderEnum, IEmailHelper> emailHelper;
        private readonly AppConfiguration _configuration = null;
        public EmailHelperRepository(Func<EmailProviderEnum, IEmailHelper> emailHelper, IOptions<AppConfiguration> config)
        {
            this.emailHelper = emailHelper;
            _configuration = config.Value;
        }
        public async Task<SendEmailResponse> SendEmail(HttpClient client, EmailRequest emailRequest)
        {
            var emailProvider = _configuration.EmailProvider;
            return await emailHelper(emailProvider).SendEmail(client, emailRequest);
        }
    }
}
