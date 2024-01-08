using Microsoft.AspNetCore.Diagnostics;

namespace Macs.WebApi.Endpoints
{
    public class MacsExceptionHandler : IExceptionHandler
    {
        private ILogger<MacsExceptionHandler> logger;

        public MacsExceptionHandler(ILogger<MacsExceptionHandler> logger)
        {
            this.logger = logger;
        }  
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            await httpContext.Response.WriteAsync($"Exception: {exception.Message}");

            return true;
        }
    }
}
