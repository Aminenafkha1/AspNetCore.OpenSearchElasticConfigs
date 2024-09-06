using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Serilog;
using Serilog.Sinks.OpenTelemetry;

namespace AspNetCore.OpenSearchElastic.API.Extensions;

public static class TelemetryExtensions
{
    public static void AddTelemetry(this IServiceCollection services,  string serviceName)
    {
        services.AddOpenTelemetry().WithTracing(b =>
        {
            b.SetResourceBuilder(ResourceBuilder
                .CreateDefault()
                .AddService(serviceName));
                
            b.SetErrorStatusOnException()
                .AddAspNetCoreInstrumentation(options =>
                {
                    options.RecordException = true;
                }).AddHttpClientInstrumentation()  
                .AddOtlpExporter();
        });
        
    }
    public static LoggerConfiguration WriteToOpenTelemetry(this LoggerConfiguration loggerConfiguration)
    {
        return loggerConfiguration.WriteTo.OpenTelemetry(c =>
        {
            c.Endpoint = "http://127.0.0.1:4317";
            c.Protocol = OtlpProtocol.Grpc;
            c.IncludedData = IncludedData.TraceIdField | IncludedData.SpanIdField | IncludedData.SourceContextAttribute;
        });
    }
}