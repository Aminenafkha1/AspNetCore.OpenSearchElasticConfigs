using Elastic.Apm.NetCoreAll;
using Elastic.Channels;
using Elastic.Serilog.Sinks;
using Elastic.Transport;
using Serilog;

namespace AspNetCore.OpenSearchElastic.API.Extensions;

public static class ElasticExtensions
{
    public static LoggerConfiguration WriteToElasticsearch(this LoggerConfiguration loggerConfiguration)
    {
        return loggerConfiguration.WriteTo.Elasticsearch([new Uri("http://10.101.0.25:9200")], opts =>
            {
                opts.BootstrapMethod = Elastic.Ingest.Elasticsearch.BootstrapMethod.Failure;
                opts.DataStream = new Elastic.Ingest.Elasticsearch.DataStreams.DataStreamName("logs", "ApplicationTest");
                opts.ConfigureChannel = channelOpts =>
                {
                    channelOpts.BufferOptions = new BufferOptions { ExportMaxConcurrency = 10 };
                };
            }/*,
            transport =>
            {
                transport.Authentication(new BasicAuthentication("elastic", "pass@123")); // Basic Auth
            }*/);
    }

    public static IApplicationBuilder UseElasticApm(this IApplicationBuilder app, IConfiguration configuration)
    {
        app.UseAllElasticApm(configuration);
        return app;
    }
}