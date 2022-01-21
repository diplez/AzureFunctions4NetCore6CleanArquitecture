using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Domain.Common.Dto.Response.Generic
{
    //https://github.com/aspnetboilerplate/aspnetboilerplate/blob/489500e7c566c1dcf955aa8f5e17c0f0b6562090/src/Abp.Web.Common/Web/Models/AjaxResponseOfTResult.cs
    public class ResponseResultAJAX<T>
    {
        [JsonProperty(PropertyName = nameof(Success))]
        public bool Success { get; set; }

        [JsonProperty(PropertyName = nameof(Result))]
        public T Result { get; set; }

        [JsonProperty(PropertyName = nameof(Error))]
        public string Error { get; set; }

        [JsonProperty(PropertyName = nameof(TargetUrl))]
        public string TargetUrl { get; set; }

        [JsonProperty(PropertyName = nameof(UnAuthorizedRequest))]
        public string UnAuthorizedRequest { get; set; }

        /// <summary>
        /// Creates an <see cref="AjaxResponse"/> object with <see cref="Result"/> specified.
        /// <see cref="AjaxResponseBase.Success"/> is set as true.
        /// </summary>
        /// <param name="result">The actual result object of AJAX request</param>
        public ResponseResultAJAX(T result)
        {
            Result = result;
            Success = true;
        }

        /// <summary>
        /// Creates an <see cref="AjaxResponse"/> object with <see cref="Result"/> specified.
        /// <see cref="AjaxResponseBase.Success"/> is set as true.
        /// </summary>
        /// <param name="result">The actual result object of AJAX request</param>
        public ResponseResultAJAX(T result,bool success)
        {
            Result = result;
            Success = success;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        public ResponseResultAJAX(string error)
        {
            Error = error;
            Success = false;
        }

        /// <summary>
        /// Creates an <see cref="AjaxResponse"/> object.
        /// <see cref="AjaxResponseBase.Success"/> is set as true.
        /// </summary>
        public ResponseResultAJAX()
        {
            Success = true;
        }

        /// <summary>
        /// Creates an <see cref="AjaxResponse"/> object with <see cref="AjaxResponseBase.Success"/> specified.
        /// </summary>
        /// <param name="success">Indicates success status of the result</param>
        public ResponseResultAJAX(bool success)
        {
            Success = success;
        }
    }
}
