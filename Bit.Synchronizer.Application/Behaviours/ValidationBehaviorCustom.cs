using Microsoft.Azure.Functions.Worker.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit.Application.Behaviours
{
    public class HttpResponseBody<T>
    {
        public bool IsValid { get; set; }
        public T Value { get; set; }

        public IEnumerable<ValidationResult> ValidationResults { get; set; }
    }

    public static class ModelValidationExtension
    {
        public static async Task<HttpResponseBody<T>> GetBodyAsync<T>(this HttpRequestData request)
        {
            string requestBody = String.Empty;
            using (StreamReader streamReader = new StreamReader(request.Body))
            {
                requestBody = await streamReader.ReadToEndAsync();
            }            
            var data = JsonConvert.DeserializeObject<T>(requestBody);
            var body = new HttpResponseBody<T>();
            body.Value = data;

            var results = new List<ValidationResult>();
            body.IsValid = Validator.TryValidateObject(body.Value, new ValidationContext(body.Value, null, null), results, true);
            body.ValidationResults = results;

            return body;
        }
    }
}
