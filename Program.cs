var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

app.Run(async (HttpContext context) =>
{
    // string method = context.Request.Method;
    var agente = context.Request.Headers.UserAgent;
    await context.Response.WriteAsync("<h1>Fala rapaziada</h1>");
    await context.Response.WriteAsync("<h2>tudo bem?</h2>");
    await context.Response.WriteAsync($"<h2>agente: {agente}</h2>");
    await context.Response.WriteAsync($"<h2>hora do momento e {DateTime.Now}</h2>");
    // await context.Response.WriteAsync($"<h3>{method}</h3>");
});

app.Run();