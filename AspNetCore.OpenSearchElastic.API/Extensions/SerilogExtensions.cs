using Serilog;

namespace AspNetCore.OpenSearchElastic.API.Extensions;

public static class SerilogExtensions
{
    public static IHostBuilder AddSerilog(this IHostBuilder hostBuilder , string serviceName) 
    {
        
        hostBuilder.UseSerilog((context,services, configs) =>
        { 
            configs
                .ReadFrom.Services(services)
                .Enrich.FromLogContext() 
                .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                .Enrich.WithProperty("ApplicationName",serviceName)
                .WriteTo.Console()
                .WriteToElasticsearch().WriteToOpenTelemetry();
        }); 
        return hostBuilder;

    }  
    public static IApplicationBuilder UseSerilog(this IApplicationBuilder app)
    {
        app.UseSerilogRequestLogging();  
        return app;
    }
}