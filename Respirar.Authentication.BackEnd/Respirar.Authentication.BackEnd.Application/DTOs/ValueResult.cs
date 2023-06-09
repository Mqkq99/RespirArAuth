using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Respirar.Authentication.BackEnd.Application.DTOs
{
    public class ValueResult<T> : BaseResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValueResult{T}"/> class.
        /// </summary>
        public ValueResult()
        {
        }

        private ValueResult(HttpStatusCode status)
        {
            Status = status;
        }

        /// <summary>
        /// Gets or sets the result value.
        /// </summary>
        public T Result { get; set; }

        /// <summary>
        /// Gets a not found result.
        /// </summary>
        /// <param name="errorMessages">List of errors.</param>
        /// <returns>Not found result.</returns>
        public static ValueResult<T> Ok(T result)
        {
            return new ValueResult<T>(HttpStatusCode.OK) { Result = result };
        }

        /// <summary>
        /// Gets a not found result.
        /// </summary>
        /// <param name="errorMessages">List of errors.</param>
        /// <returns>Not found result.</returns>
        public static ValueResult<T> NotFound(params string[] errorMessages)
        {
            return new ValueResult<T>(HttpStatusCode.NotFound) { Errors = errorMessages };
        }


        /// <summary>
        /// Gets a error result.
        /// </summary>
        /// <param name="errorMessages">List of errors.</param>
        /// <returns>Not error result.</returns>
        public static ValueResult<T> Error(params string[] errorMessages)
        {
            return new ValueResult<T>(HttpStatusCode.InternalServerError) { Errors = errorMessages };
        }
    }
}
