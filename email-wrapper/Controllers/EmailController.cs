using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using email_wrapper.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using email_wrapper.Helpers;
using email_wrapper.Contracts;

namespace email_wrapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        //private readonly ILogger<EmailController> _logger;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IEmailHelperRepository _emailHelperRepository;

        //Constructor using dependency injection
        public EmailController(IHttpClientFactory clientFactory, IEmailHelperRepository emailHelperRepository)
        {
            //_logger = logger;
            _clientFactory = clientFactory;
            _emailHelperRepository = emailHelperRepository;
        }

        // GET /api/email
        [HttpGet]
        public string HealthCheck()
        {
            return "App is healthy!";
        }

        // POST /api/email
        [HttpPost]
        public async Task<SendEmailResponse> SendEmail(EmailRequest emailRequest)
        {
            try { 
            if (!emailRequest.isValid())
            {
                return new SendEmailResponse(false, "Please fix input fields. They are either empty or invalid.");
            }

            var client = _clientFactory.CreateClient();
            SendEmailResponse response = new SendEmailResponse();
            response = await _emailHelperRepository.SendEmail(client, emailRequest);
            return response ?? throw new Exception("Response from Email Provider is Null."); 
            }
            catch(Exception ex) {
                //log exception
                Console.WriteLine(ex.Message);
                return new SendEmailResponse(false, "Oops! Something went wrong, please try again later.");
            }


        }
    }
}