using Asp.NetPlayground;

var builder  = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddHostedService<Worker>();

services.AddControllers();

var app = builder.Build();

app.Run();