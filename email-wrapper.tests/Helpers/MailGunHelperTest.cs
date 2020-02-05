using email_wrapper.Helpers;
using email_wrapper.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;
using NSubstitute;
using System.Net.Http;
using Newtonsoft.Json;

namespace email_wrapper.tests.Helpers
{
    public class MailGunHelperTest: TestsBase
    {
        [Fact]
        public async void SendEmailReturnsSuccessResponse()
        {
            // Arrange
            var emailRequest = new EmailRequest();
            emailRequest.To = "abc@example.com";
            emailRequest.To_name = "John Doe";
            emailRequest.From = "xyz@test.com";
            emailRequest.From_name = "Jane Doe";
            emailRequest.Subject = "Your Bill";
            emailRequest.Body = "$100";


            //expectedResponse.Content //@"{StatusCode: 400, ReasonPhrase: 'BAD REQUEST', Version: 1.1, Content: System.Net.Http.HttpConnectionResponseContent, Headers:{Date: Wed, 05 Feb 2020 02:42:25 GMTServer: nginxConnection: keep-aliveContent-Type: application/jsonContent-Length: 157}}";
            var mailGunHelper = new MailGunHelper();
            var mockResponseFromApi = JsonConvert.SerializeObject(new { id = "1234", message = "Message sent succesfully" });
            var expectedResponse = new SendEmailResponse(true, "Email queued and will be sent shortly");

            var mockMessageHandler = new MockHttpMessageHandler(mockResponseFromApi, HttpStatusCode.OK);
            var httpClient = new HttpClient(mockMessageHandler);
            
            // Act
            var actualResponse = await mailGunHelper.SendEmail(httpClient, emailRequest);

            // Assert
            Assert.Equal(expectedResponse.IsEmailSent, actualResponse.IsEmailSent);
            Assert.Equal(expectedResponse.Message, actualResponse.Message);

        }

        [Fact]
        public async void SendEmailReturnsFailureResponse()
        {
            // Arrange
            var emailRequest = new EmailRequest();
            emailRequest.To = "";
            emailRequest.To_name = "John Doe";
            emailRequest.From = "xyz.com";
            emailRequest.From_name = "Jane Doe";
            emailRequest.Subject = "Your Bill";
            emailRequest.Body = "$100";

            //expectedResponse.Content //@"{StatusCode: 400, ReasonPhrase: 'BAD REQUEST', Version: 1.1, Content: System.Net.Http.HttpConnectionResponseContent, Headers:{Date: Wed, 05 Feb 2020 02:42:25 GMTServer: nginxConnection: keep-aliveContent-Type: application/jsonContent-Length: 157}}";
            var mailGunHelper = new MailGunHelper();
            var mockResponseFromApi = "Mailgun returns weird reponse";
            var expectedResponse = new SendEmailResponse(false, "Oops! Something went wrong. Please try again later.");

            var mockMessageHandler = new MockHttpMessageHandler(mockResponseFromApi, HttpStatusCode.NotFound);
            var httpClient = new HttpClient(mockMessageHandler);
            
            // Act
            var actualResponse = await mailGunHelper.SendEmail(httpClient, emailRequest);

            // Assert
            Assert.Equal(expectedResponse.IsEmailSent, actualResponse.IsEmailSent);
            Assert.Equal(expectedResponse.Message, actualResponse.Message);

        }
    }
}
