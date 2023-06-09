using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Respirar.Authentication.BackEnd.Application.DTOs
{
    public class BaseResult : IResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseResult"/> class.
        /// </summary>
        public BaseResult()
        {
        }

        /// <inheritdoc/>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public HttpStatusCode Status { get; init; } = HttpStatusCode.OK;

        /// <inheritdoc/>
        [JsonIgnore]
        public bool IsSuccess => Status == HttpStatusCode.OK;

        /// <inheritdoc/>
        public string SuccessMessage { get; set; } = string.Empty;

        /// <inheritdoc/>
        public IEnumerable<string> Errors { get; init; } = new List<string>();
    }
}
