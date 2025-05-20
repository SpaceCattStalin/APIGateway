var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("https://localhost:7212/swagger/v1/swagger.json", "Knowledgebase API");
        c.SwaggerEndpoint("https://localhost:7213/swagger/v1/swagger.json", "Chat API");
        c.SwaggerEndpoint("https://localhost:7214/swagger/v1/swagger.json", "User API");
    });
}


app.MapReverseProxy();

app.Run();
