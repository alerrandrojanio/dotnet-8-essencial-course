namespace CatalogAPI.Extensions;

public static class ApiExceptionMiddlewareExternsions {
    public statis void Configure(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError => 
        {
            appError.Run(async context => 
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Feature.Get<IExceptionHendlerFeature>();

                if (contextFeature != null)
                {
                    await context.Response.WriteAsync(new ErrorDetails()
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = contextFeature.Error.Message,
                        Trace = contextFeature.Error.StackTrace
                    }.Serialize());
                }
            };)
        });
    }
}