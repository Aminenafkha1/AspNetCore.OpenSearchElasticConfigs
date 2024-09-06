using AspNetCore.OpenSearchElastic.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;
 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTelemetry("testService");
builder.Host.AddSerilog("testService");
builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseElasticApm(configuration);
app.UseSerilog();
app.MapControllers();


app.Run();
 