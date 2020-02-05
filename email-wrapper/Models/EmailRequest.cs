using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace email_wrapper.Models
{
    /// <summary>
    /// Class EmailRequest builds an object to accept email requests for the email API.
    /// </summary>
    public class EmailRequest
    {
        /// <summary>
        /// Gets or sets an email object containing the email address of the recipient
        /// </summary>
        public string To { get; set; }
        /// <summary>
        /// Gets or sets an email object containing the name of the recipient
        /// </summary>
        public string To_name { get; set; }
        /// <summary>
        /// Gets or sets an email object containing the email address of the sender
        /// </summary>
        public string From { get; set; }
        /// <summary>
        /// Gets or sets an email object containing the name of the sender
        /// </summary>
        public string From_name { get; set; }
        /// <summary>
        /// Gets or sets an email object containing the Subject of the email
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// Gets or sets an email object containing the body of the email
        /// </summary>
        public string Body { get; set; }

        public bool isValid()
        {
            if (string.IsNullOrWhiteSpace(To) || !isEmailValid(To))
            {
                return false;
            }

            if(string.IsNullOrWhiteSpace(To_name) || !isNameValid(To_name))
            {
                return false;
            }

            if(string.IsNullOrWhiteSpace(From) || !isEmailValid(From))
            {
                return false;
            }

            if(string.IsNullOrWhiteSpace(From_name) || !isNameValid(From_name))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(Subject))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(Body))
            {
                return false;
            }
            return true;
        }

        bool isNameValid(string name)
        {
            string namePattern = @"[a-zA-Z'\s.-]+";
            var regex = new Regex(namePattern);
            return regex.IsMatch(name);
        }

        bool isEmailValid(string email)
        {
            string emailPattern = @"\b[\w\.-]+@[\w\.-]+\.\w{2,4}\b";
            var regex = new Regex(emailPattern);
            return regex.IsMatch(email);
        }
    }
}
