using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace email_wrapper.Models.SendGrid
{
    /// <summary>
    /// Specifies the content of your email. You can include multiple mime types of content, but you must specify at least one. To include more than one mime type, simply add another object to the array containing the type and value parameters. If included, text/plain and text/html must be the first indices of the array in this order. If you choose to include the text/plain or text/html mime types, they must be the first indices of the content array in the order text/plain, text/html.*Content is NOT mandatory if you using a transactional template and have defined the template_id in the Request
    /// </summary>
    [JsonObject(IsReference = false)]
    public class Content
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Content"/> class.
        /// </summary>
        public Content()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Content"/> class.
        /// </summary>
        /// <param name="type">The mime type of the content you are including in your email. For example, text/plain or text/html.</param>
        /// <param name="value">The actual content of the specified mime type that you are including in your email.</param>
        public Content(string type, string value)
        {
            this.Type = type;
            this.Value = value;
        }

        /// <summary>
        /// Gets or sets the mime type of the content you are including in your email. For example, text/plain or text/html.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the actual content of the specified mime type that you are including in your email.
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}
