using email_wrapper.Contracts;
using email_wrapper.Models;
using email_wrapper.Models.SendGrid;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace email_wrapper.Helpers
{
    public class SendGridHelper: IEmailHelper
    {
        public async Task<SendEmailResponse> SendEmail(HttpClient client, EmailRequest emailRequest)
        {
            var request = new HttpRequestMessage(HttpMethod.Post,
                "https://api.sendgrid.com/v3/mail/send");
            //string apiKey = " " + Credentials.SendGridApiKey;

            var byteArray = new UTF8Encoding().GetBytes(Credentials.SendGridApiKey);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Credentials.SendGridApiKey);//Convert.ToBase64String(byteArray));

            //request.Content = new FormUrlEncodedContent(formData);
            //var serializedFormData = JsonConvert.SerializeObject(formData);
            var sendGridMessage = new SendGridMessage();
            
            var to = new EmailAddress(emailRequest.To, emailRequest.To_name);
            var tos = new List<EmailAddress>
            {
                to
            };
            var personalization = new Personalization
            {
                Tos = tos
            };
            sendGridMessage.Personalizations = new List<Personalization> { personalization };
            
            sendGridMessage.From = new EmailAddress(emailRequest.From, emailRequest.From_name);
            sendGridMessage.Subject = emailRequest.Subject;
            
            var emailContent = new Content("text/html", emailRequest.Body);
            sendGridMessage.Contents = new List<Content> 
            { 
                emailContent 
            };
            var serializedRequest = JsonConvert.SerializeObject(sendGridMessage);
            //var serializedRequest = "{  \"personalizations\": [    {      \"to\": [        {          \"email\": \"prashanth.ashokramkumar@gmail.com\"        }      ]    }  ],  \"from\": {    \"email\": \"prashanth.ashokram@gmail.com\"  },  \"subject\": \"Sending with SendGrid is Fun\",  \"content\": [    {      \"type\": \"text/html\",      \"value\": \"and easy to do anywhere, even with <strong>cURL</strong>\"    }  ]}";
            request.Content = new StringContent(serializedRequest, Encoding.UTF8, "application/json");

            var result = await client.SendAsync(request);
            SendEmailResponse response = new SendEmailResponse();
            if (result.IsSuccessStatusCode)
            {
                response.IsEmailSent = true;
                response.Message = "Email queued and will be sent shortly";
            }
            else
            {
                //log error and return generic error response
                response.IsEmailSent = true;
                response.Message= "Oops! Something went wrong. Please try again later.";
            }
            return response;
        }
    }
}
