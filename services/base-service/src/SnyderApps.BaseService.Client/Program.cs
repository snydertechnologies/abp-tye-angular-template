using Volo.Abp;
using Microsoft.AspNetCore.Mvc;
using SnyderApps.BaseService.Client;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseAutofac();
builder.Services.ReplaceConfiguration(builder.Configuration);
builder.Services.AddApplication<MinimalModule>();

var app = builder.Build();

app.MapGet("/hi", ([FromServices] HelloService helloService) =>
{
	return helloService.SayHi();
});

app.InitializeApplication();
app.Run();