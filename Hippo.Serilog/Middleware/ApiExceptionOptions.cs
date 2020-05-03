using System;
using Microsoft.AspNetCore.Http;

namespace Hippo.Serilog.Middleware
{
    public class ApiExceptionOptions
    {       
        public Action<HttpContext, Exception, ApiError> AddResponseDetails { get; set; }        
    }
}
