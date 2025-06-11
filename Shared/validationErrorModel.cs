using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
namespace Shared
{
    public  class validationErrorModel
    {
        public int StatusCode { get; set; } = (int)HttpStatusCode.BadRequest;
        public string ErrorMessage { get; set; } = "Validation Error";
        public IEnumerable<validationError> validationErrors { get; set; } = new List<validationError>();
    }
}
