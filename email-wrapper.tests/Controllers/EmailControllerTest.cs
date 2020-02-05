using email_wrapper.Controllers;
using email_wrapper.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using NSubstitute;
using System.Net.Http;

namespace email_wrapper.tests.Controllers
{
    
    public class EmailControllerTest: TestsBase
    {
        #region Testing To field
        
        [Fact]
        public async void EmailRequestHasEmptyTo()
        {
            //Arrange
            var controller = new EmailController(_mockHttpClientFactory, _mockEmailHelperRepository);

            EmailRequest emailRequest = new EmailRequest();
            emailRequest.To = "";
            var expectedResponse = new SendEmailResponse(false, "Please fix input fields. They are either empty or invalid.");

            //Act
            var actualResponse = await controller.SendEmail(emailRequest);

            //Assert

            Assert.Equal(expectedResponse.IsEmailSent, actualResponse.IsEmailSent);
            Assert.Equal(expectedResponse.Message, actualResponse.Message);
        }

        [Fact]
        public async void EmailRequestHasInvalidTo()
        {
            //Arrange
            var controller = new EmailController(_mockHttpClientFactory, _mockEmailHelperRepository);

            EmailRequest emailRequest = new EmailRequest();
            emailRequest.To = "!@#";
            var expectedResponse = new SendEmailResponse(false, "Please fix input fields. They are either empty or invalid.");

            //Act
            var actualResponse = await controller.SendEmail(emailRequest);

            //Assert

            Assert.Equal(expectedResponse.IsEmailSent, actualResponse.IsEmailSent);
            Assert.Equal(expectedResponse.Message, actualResponse.Message);
        }

        [Fact]
        public async void EmailRequestHasValidTo()
        {
            //Arrange
            var controller = new EmailController(_mockHttpClientFactory, _mockEmailHelperRepository);

            EmailRequest emailRequest = new EmailRequest();
            emailRequest.To = "abc@example.com";
            var expectedResponse = new SendEmailResponse(false, "Please fix input fields. They are either empty or invalid.");

            //Act
            var actualResponse = await controller.SendEmail(emailRequest);

            //Assert

            Assert.Equal(expectedResponse.IsEmailSent, actualResponse.IsEmailSent);
            Assert.Equal(expectedResponse.Message, actualResponse.Message);
        }
        #endregion

        #region Testing ToName field

        [Fact]
        public async void EmailRequestHasEmptyToName()
        {
            //Arrange
            var controller = new EmailController(_mockHttpClientFactory, _mockEmailHelperRepository);

            EmailRequest emailRequest = new EmailRequest();
            emailRequest.To = "abc@example.com";
            emailRequest.To_name = "";
            var expectedResponse = new SendEmailResponse(false, "Please fix input fields. They are either empty or invalid.");

            //Act
            var actualResponse = await controller.SendEmail(emailRequest);

            //Assert

            Assert.Equal(expectedResponse.IsEmailSent, actualResponse.IsEmailSent);
            Assert.Equal(expectedResponse.Message, actualResponse.Message);
        }

        [Fact]
        public async void EmailRequestHasInvalidToName()
        {
            //Arrange
            var controller = new EmailController(_mockHttpClientFactory, _mockEmailHelperRepository);

            EmailRequest emailRequest = new EmailRequest();
            emailRequest.To = "abc@example.com";
            emailRequest.To_name = "!@#";
            var expectedResponse = new SendEmailResponse(false, "Please fix input fields. They are either empty or invalid.");

            //Act
            var actualResponse = await controller.SendEmail(emailRequest);

            //Assert

            Assert.Equal(expectedResponse.IsEmailSent, actualResponse.IsEmailSent);
            Assert.Equal(expectedResponse.Message, actualResponse.Message);
        }

        [Fact]
        public async void EmailRequestHasValidToName()
        {
            //Arrange
            var controller = new EmailController(_mockHttpClientFactory, _mockEmailHelperRepository);

            EmailRequest emailRequest = new EmailRequest();
            emailRequest.To = "abc@example.com";
            emailRequest.To_name = "John Doe";
            var expectedResponse = new SendEmailResponse(false, "Please fix input fields. They are either empty or invalid.");

            //Act
            var actualResponse = await controller.SendEmail(emailRequest);

            //Assert

            Assert.Equal(expectedResponse.IsEmailSent, actualResponse.IsEmailSent);
            Assert.Equal(expectedResponse.Message, actualResponse.Message);
        }
        #endregion

        #region Testing From field

        [Fact]
        public async void EmailRequestHasEmptyFrom()
        {
            //Arrange
            var controller = new EmailController(_mockHttpClientFactory, _mockEmailHelperRepository);

            EmailRequest emailRequest = new EmailRequest();
            emailRequest.To = "abc@example.com";
            emailRequest.To_name = "John Doe";
            emailRequest.From = "";
            var expectedResponse = new SendEmailResponse(false, "Please fix input fields. They are either empty or invalid.");

            //Act
            var actualResponse = await controller.SendEmail(emailRequest);

            //Assert

            Assert.Equal(expectedResponse.IsEmailSent, actualResponse.IsEmailSent);
            Assert.Equal(expectedResponse.Message, actualResponse.Message);
        }

        [Fact]
        public async void EmailRequestHasInvalidFrom()
        {
            //Arrange
            var controller = new EmailController(_mockHttpClientFactory, _mockEmailHelperRepository);

            EmailRequest emailRequest = new EmailRequest();
            emailRequest.To = "abc@example.com";
            emailRequest.To_name = "John Doe";
            emailRequest.From = "!@#";
            var expectedResponse = new SendEmailResponse(false, "Please fix input fields. They are either empty or invalid.");

            //Act
            var actualResponse = await controller.SendEmail(emailRequest);

            //Assert

            Assert.Equal(expectedResponse.IsEmailSent, actualResponse.IsEmailSent);
            Assert.Equal(expectedResponse.Message, actualResponse.Message);
        }

        [Fact]
        public async void EmailRequestHasValidFrom()
        {
            //Arrange
            var controller = new EmailController(_mockHttpClientFactory, _mockEmailHelperRepository);

            EmailRequest emailRequest = new EmailRequest();
            emailRequest.To = "abc@example.com";
            emailRequest.To_name = "John Doe";
            emailRequest.From = "xyz@test.com";
            var expectedResponse = new SendEmailResponse(false, "Please fix input fields. They are either empty or invalid.");

            //Act
            var actualResponse = await controller.SendEmail(emailRequest);

            //Assert

            Assert.Equal(expectedResponse.IsEmailSent, actualResponse.IsEmailSent);
            Assert.Equal(expectedResponse.Message, actualResponse.Message);
        }
        #endregion

        #region Testing From Name field

        [Fact]
        public async void EmailRequestHasEmptyFromName()
        {
            //Arrange
            var controller = new EmailController(_mockHttpClientFactory, _mockEmailHelperRepository);

            EmailRequest emailRequest = new EmailRequest();
            emailRequest.To = "abc@example.com";
            emailRequest.To_name = "John Doe";
            emailRequest.From = "xyz@test.com";
            emailRequest.From_name = "";
            var expectedResponse = new SendEmailResponse(false, "Please fix input fields. They are either empty or invalid.");

            //Act
            var actualResponse = await controller.SendEmail(emailRequest);

            //Assert

            Assert.Equal(expectedResponse.IsEmailSent, actualResponse.IsEmailSent);
            Assert.Equal(expectedResponse.Message, actualResponse.Message);
        }

        [Fact]
        public async void EmailRequestHasInvalidFromName()
        {
            //Arrange
            var controller = new EmailController(_mockHttpClientFactory, _mockEmailHelperRepository);

            EmailRequest emailRequest = new EmailRequest();
            emailRequest.To = "abc@example.com";
            emailRequest.To_name = "John Doe";
            emailRequest.From = "xyz@test.com";
            emailRequest.From_name = "!@#";
            var expectedResponse = new SendEmailResponse(false, "Please fix input fields. They are either empty or invalid.");

            //Act
            var actualResponse = await controller.SendEmail(emailRequest);

            //Assert

            Assert.Equal(expectedResponse.IsEmailSent, actualResponse.IsEmailSent);
            Assert.Equal(expectedResponse.Message, actualResponse.Message);
        }

        [Fact]
        public async void EmailRequestHasValidFromName()
        {
            //Arrange
            var controller = new EmailController(_mockHttpClientFactory, _mockEmailHelperRepository);

            EmailRequest emailRequest = new EmailRequest();
            emailRequest.To = "abc@example.com";
            emailRequest.To_name = "John Doe";
            emailRequest.From = "xyz@test.com";
            emailRequest.From_name = "Jane Doe";
            var expectedResponse = new SendEmailResponse(false, "Please fix input fields. They are either empty or invalid.");

            //Act
            var actualResponse = await controller.SendEmail(emailRequest);

            //Assert

            Assert.Equal(expectedResponse.IsEmailSent, actualResponse.IsEmailSent);
            Assert.Equal(expectedResponse.Message, actualResponse.Message);
        }
        #endregion

        #region Testing Subject field

        [Fact]
        public async void EmailRequestHasEmptySubject()
        {
            //Arrange
            var controller = new EmailController(_mockHttpClientFactory, _mockEmailHelperRepository);

            EmailRequest emailRequest = new EmailRequest();
            emailRequest.To = "abc@example.com";
            emailRequest.To_name = "John Doe";
            emailRequest.From = "xyz@test.com";
            emailRequest.From_name = "Jane Doe";
            emailRequest.Subject = "";
            var expectedResponse = new SendEmailResponse(false, "Please fix input fields. They are either empty or invalid.");

            //Act
            var actualResponse = await controller.SendEmail(emailRequest);

            //Assert

            Assert.Equal(expectedResponse.IsEmailSent, actualResponse.IsEmailSent);
            Assert.Equal(expectedResponse.Message, actualResponse.Message);
        }


        [Fact]
        public async void EmailRequestHasValidSubject()
        {
            //Arrange
            var controller = new EmailController(_mockHttpClientFactory, _mockEmailHelperRepository);

            EmailRequest emailRequest = new EmailRequest();
            emailRequest.To = "abc@example.com";
            emailRequest.To_name = "John Doe";
            emailRequest.From = "xyz@test.com";
            emailRequest.From_name = "Jane Doe";
            emailRequest.Subject = "Your Bill";
            var expectedResponse = new SendEmailResponse(false, "Please fix input fields. They are either empty or invalid.");

            //Act
            var actualResponse = await controller.SendEmail(emailRequest);

            //Assert

            Assert.Equal(expectedResponse.IsEmailSent, actualResponse.IsEmailSent);
            Assert.Equal(expectedResponse.Message, actualResponse.Message);
        }
        #endregion

        #region Testing Body field

        [Fact]
        public async void EmailRequestHasEmptyBody()
        {
            //Arrange
            var controller = new EmailController(_mockHttpClientFactory, _mockEmailHelperRepository);

            EmailRequest emailRequest = new EmailRequest();
            emailRequest.To = "abc@example.com";
            emailRequest.To_name = "John Doe";
            emailRequest.From = "xyz@test.com";
            emailRequest.From_name = "Jane Doe";
            emailRequest.Subject = "Your bill";
            emailRequest.Body = "";
            var expectedResponse = new SendEmailResponse(false, "Please fix input fields. They are either empty or invalid.");

            //Act
            var actualResponse = await controller.SendEmail(emailRequest);

            //Assert

            Assert.Equal(expectedResponse.IsEmailSent, actualResponse.IsEmailSent);
            Assert.Equal(expectedResponse.Message, actualResponse.Message);
        }


        [Fact]
        public async void EmailRequestHasValidBody()
        {
            //Arrange
            var controller = new EmailController(_mockHttpClientFactory, _mockEmailHelperRepository);

            

            EmailRequest emailRequest = new EmailRequest();
            emailRequest.To = "abc@example.com";
            emailRequest.To_name = "John Doe";
            emailRequest.From = "xyz@test.com";
            emailRequest.From_name = "Jane Doe";
            emailRequest.Subject = "Your Bill";
            emailRequest.Body = "$100";
            
            var expectedResponse = new SendEmailResponse(true, "Email queued and will be sent shortly");
            _mockEmailHelperRepository.SendEmail(_mockHttpClient, emailRequest).ReturnsForAnyArgs(expectedResponse);

            //Act
            var actualResponse = await controller.SendEmail(emailRequest);

            //Assert

            Assert.Equal(expectedResponse.IsEmailSent, actualResponse.IsEmailSent);
            Assert.Equal(expectedResponse.Message, actualResponse.Message);
        }
        #endregion

        [Fact]
        public async void EmailControllerThrowsException()
        {
            //Arrange
            var controller = new EmailController(_mockHttpClientFactory, _mockEmailHelperRepository);



            EmailRequest emailRequest = new EmailRequest();
            emailRequest.To = "abc@example.com";
            emailRequest.To_name = "John Doe";
            emailRequest.From = "xyz@test.com";
            emailRequest.From_name = "Jane Doe";
            emailRequest.Subject = "Your Bill";
            emailRequest.Body = "$100";

            var expectedResponse = new SendEmailResponse(false, "Oops! Something went wrong, please try again later.");

            //Commenting out mock client on purpose to test exception scenario
            //_mockEmailHelperRepository.SendEmail(_mockHttpClient, emailRequest).ReturnsForAnyArgs(expectedResponse);

            //Act
            var actualResponse = await controller.SendEmail(emailRequest);

            //Assert

            //await Assert.ThrowsAsync<Exception>(() => controller.SendEmail(emailRequest));
            Assert.Equal(expectedResponse.IsEmailSent, actualResponse.IsEmailSent);
            Assert.Equal(expectedResponse.Message, actualResponse.Message);
        }
    }
}
