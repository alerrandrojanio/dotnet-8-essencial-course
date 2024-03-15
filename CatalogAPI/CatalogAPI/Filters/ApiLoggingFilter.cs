using Microsoft.AspNetCore.Mvc.Filters;

namespace CatalogAPI.Filters;

public class ApiLoggingFilter : IActionFilter {
    private readonly ILogger<ApiLoggingFilter> _logger;

    public ApiLoggingFilter(ILogger<ApiLoggingFilter> logger)
    {
        _logger = logger;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _logger.LogInformation($"{DateTime.Now.ToLongTimeString()}");
    }
}