using Newtonsoft.Json;
using System.Net;

namespace HostGallery.WebAPI.Middlewares; 

public class ErrorMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ErrorMiddleware(RequestDelegate next, IWebHostEnvironment webHostEnvironment)
    {
        _next = next;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        ErrorResponse errorResponseVm;

        if (_webHostEnvironment.IsDevelopment())
        {
            errorResponseVm = new ErrorResponse(HttpStatusCode.BadRequest.ToString(),
                                                    $"{ex.Message} {ex?.InnerException?.Message}");
        }
        else
        {
            errorResponseVm = new ErrorResponse(HttpStatusCode.BadRequest.ToString(),
                                                    "Ocorreu um erro durante a execução do EndPoint!");
        }

        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        var result = JsonConvert.SerializeObject(errorResponseVm);
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(result);
    }
    
}

public class ErrorResponse
{
    public ErrorResponse()
    {
        TraceId = Guid.NewGuid().ToString();
        Errors = new List<ErrorDetails>();
    }

    public ErrorResponse(string logref, string message)
    {
        TraceId = Guid.NewGuid().ToString();
        Errors = new List<ErrorDetails>();
        AddError(logref, message);
    }

    public string TraceId { get; private set; }
    public List<ErrorDetails> Errors { get; private set; }

    public class ErrorDetails
    {
        public ErrorDetails(string logref, string message)
        {
            Logref = logref;
            Message = message;
        }

        public string Logref { get; private set; }

        public string Message { get; private set; }
    }

    public void AddError(string logref, string message)
    {
        Errors.Add(new ErrorDetails(logref, message));
    }
}
