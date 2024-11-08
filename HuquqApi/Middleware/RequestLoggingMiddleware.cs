using Google;
using HuquqApi.Model;

namespace HuquqApi.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger, IServiceScopeFactory scopeFactory)
        {
            _next = next;
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var ipAddress = context.Connection.RemoteIpAddress?.MapToIPv4().ToString();
            var requestPath = context.Request.Path;
            var timestamp = DateTime.UtcNow;
            var isSuccessful = true;
            string errorMessage = null;
            string stackTrace = null;

            try
            {
                await _next(context);

                // 401 veya diğer durum kodlarını kontrol etme
                if (context.Response.StatusCode == 401)
                {
                    isSuccessful = false;
                    errorMessage = "Unauthorized access (401)";
                    stackTrace = "No stack trace available";
                }
                else if (context.Response.StatusCode >= 400)
                {
                    isSuccessful = false;
                    errorMessage = $"HTTP Error {context.Response.StatusCode}";
                    stackTrace = "No stack trace available";
                }
            }
            catch (Exception ex)
            {
                isSuccessful = false;
                errorMessage = ex.Message;
                stackTrace = ex.StackTrace;
                _logger.LogError(ex, $"Başarısız API isteği: IP = {ipAddress}, Path = {requestPath}");
                throw;
            }
            finally
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<HuquqDbContext>();
                    var requestLog = new RequestLog
                    {
                        IpAddress = ipAddress,
                        MacAddress = context.Request.Headers["MacAddress"].ToString(),
                        Path = requestPath,
                        Timestamp = timestamp,
                        IsSuccessful = isSuccessful,
                        ErrorMessage = errorMessage ?? "No error",
                        StackTrace = stackTrace ?? "No stack trace"
                    };

                    dbContext.RequestLogs.Add(requestLog);
                    await dbContext.SaveChangesAsync();
                }
            }
        }

    }

}
