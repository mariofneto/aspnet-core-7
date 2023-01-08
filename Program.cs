var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

app.Run(async (HttpContext context)=>{
    await context.Response.WriteAsync("Fala rapaziada");
    await context.Response .WriteAsync("Tudo bem?");
});

app.Run();