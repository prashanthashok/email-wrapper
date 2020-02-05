using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace email_wrapper.Models.SendGrid
{
    /// <summary>
    /// Class SendGridMessage builds an object that sends an email through Twilio SendGrid.
    /// </summary>
    public class SendGridMessage
    {
        /// <summary>
        /// Gets or sets an email object containing the email address and name of the sender. Unicode encoding is not supported for the from field.
        /// </summary>
        [JsonProperty(PropertyName = "from")]
        public EmailAddress From { get; set; }

        /// <summary>
        /// Gets or sets the subject of your email. This may be overridden by personalizations[x].subject.
        /// </summary>
        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }
        /// <summary>
        /// Gets or sets a list of messages and their metadata. Each object within personalizations can be thought of as an envelope - it defines who should receive an individual message and how that message should be handled. For more information, please see our documentation on Personalizations. Parameters in personalizations will override the parameters of the same name from the message level.
        /// https://sendgrid.com/docs/Classroom/Send/v3_Mail_Send/personalizations.html
        /// </summary>
        [JsonProperty(PropertyName = "personalizations", IsReference = false)]
        public List<Personalization> Personalizations { get; set; }
        /// <summary>
        /// Gets or sets a list in which you may specify the content of your email. You can include multiple mime types of content, but you must specify at least one. To include more than one mime type, simply add another object to the array containing the type and value parameters. If included, text/plain and text/html must be the first indices of the array in this order. If you choose to include the text/plain or text/html mime types, they must be the first indices of the content array in the order text/plain, text/html.*Content is NOT mandatory if you using a transactional template and have defined the template_id in the Request
        /// </summary>
        [JsonProperty(PropertyName = "content", IsReference = false)]
        public List<Content> Contents { get; set; }
    }
}
