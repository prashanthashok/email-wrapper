using email_wrapper.Contracts;
using email_wrapper.Models;
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
    public class MailGunHelper: IEmailHelper
    {
        public async Task<SendEmailResponse> SendEmail(HttpClient client, EmailRequest emailRequest)
        {
            try
            {
                var formData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("from", emailRequest.From_name + " <postmaster@sandboxa48a42c6cc7a471191690ef4325979d3.mailgun.org>"),
                new KeyValuePair<string, string>("to", emailRequest.To_name + " <" + emailRequest.To + ">"),
                new KeyValuePair<string, string>("subject", emailRequest.Subject),
                new KeyValuePair<string, string>("html", emailRequest.Body)
            };
                var request = new HttpRequestMessage(HttpMethod.Post,
                    "https://api.mailgun.net/v3/sandboxa48a42c6cc7a471191690ef4325979d3.mailgun.org/messages");
                string apiKey = "api:" + Credentials.MailGunApiKey;
                var byteArray = new UTF8Encoding().GetBytes(apiKey);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                request.Content = new FormUrlEncodedContent(formData);

                var result = await client.SendAsync(request);
                SendEmailResponse response = new SendEmailResponse();
                if (result.IsSuccessStatusCode)
                {
                    var responseAsString = await result.Content.ReadAsStringAsync();
                    var responseFromApi = JsonConvert.DeserializeObject<MailGunResponse>(responseAsString);
                    if (!string.IsNullOrWhiteSpace(responseFromApi.id)) //If id is not empty, that means Mailgun queued the message
                    {
                        response.IsEmailSent = true;
                        response.Message = "Email queued and will be sent shortly";
                    }
                }
                else
                {
                    // log status code and additional error fields
                    response.IsEmailSent = false;
                    response.Message = "Oops! Something went wrong. Please try again later.";
                }

                return response;
            } 
            catch(Exception ex)
            {
                // log exception
                return new SendEmailResponse(false, "Oops! Something went wrong. Please try again later.");
            }
        }
    }
}
