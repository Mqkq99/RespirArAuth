using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Respirar.Authentication.BackEnd.Application.DTOs
{
    public interface IResult
    {
        /// <summary>
        /// Gets the status of the call.
        /// </summary>
        HttpStatusCode Status { get; }

        /// <summary>
        /// Gets a value indicating whether if the result was Succesfull.
        /// </summary>
        bool IsSuccess { get; }

        /// <summary>
        /// Gets the SuccessMessage.
        /// </summary>
        string SuccessMessage { get; }

        /// <summary>
        /// Gets the errors.
        /// </summary>
        IEnumerable<string> Errors { get; init; }
    }
}
