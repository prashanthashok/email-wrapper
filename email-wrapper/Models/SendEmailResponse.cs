using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace email_wrapper.Models
{
    public class SendEmailResponse
    {
        public bool IsEmailSent { get; set; }
        public string Message { get; set; }
        public SendEmailResponse()
        {
        }

        public SendEmailResponse(bool isEmailSent, string response)
        {
            IsEmailSent = isEmailSent;
            Message = response;
        }
    }
}
