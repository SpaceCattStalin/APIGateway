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
        c.SwaggerEndpoint("http://localhost:5003/swagger/v1/swagger.json", "Knowledgebase API");
        c.SwaggerEndpoint("http://localhost:5001/swagger/v1/swagger.json", "Chat API");
        c.SwaggerEndpoint("http://localhost:5002/swagger/v1/swagger.json", "User API");
    });
}


app.MapReverseProxy();

app.Run();
