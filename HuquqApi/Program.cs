using HuquqApi;
using FluentValidation;
using HuquqApi.Middleware;
using AspNetCoreRateLimit;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Register(builder.Configuration);
var app = builder.Build();
app.UseMiddleware<RequestLoggingMiddleware>();

app.UseStatusCodePages();

app.UseIpRateLimiting();
app.UseMiddleware<HuquqApi.Middleware.RateLimitRedirectMiddleware>();


app.UseSwagger();
    app.UseSwaggerUI();


// Middleware yapýlandýrmasý
app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigins");

app.UseAuthentication(); 
app.UseAuthorization();

app.MapControllers();

app.Run();
