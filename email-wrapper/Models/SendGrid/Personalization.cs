using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace email_wrapper.Models.SendGrid
{
    public class Personalization
    {
        /// <summary>
        /// Gets or sets an array of recipients. Each email object within this array may contain the recipient’s name, but must always contain the recipient’s email.
        /// </summary>
        [JsonProperty(PropertyName = "to", IsReference = false)]
        public List<EmailAddress> Tos { get; set; }

        /// <summary>
        /// Gets or sets an array of recipients who will receive a copy of your email. Each email object within this array may contain the recipient’s name, but must always contain the recipient’s email.
        /// </summary>
        [JsonProperty(PropertyName = "cc", IsReference = false)]
        public List<EmailAddress> Ccs { get; set; }

        
    }
}
