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
        //c.SwaggerEndpoint("https://localhost:7212/swagger/v1/swagger.json", "Knowledgebase API");
        //c.SwaggerEndpoint("https://localhost:7213/swagger/v1/swagger.json", "Chat API");
        //c.SwaggerEndpoint("https://localhost:7214/swagger/v1/swagger.json", "User API");
        //c.SwaggerEndpoint("https://localhost:7064/swagger/v1/swagger.json", "Application API");
        //c.SwaggerEndpoint("https://localhost:7150/swagger/v1/swagger.json", "College Info API");
        //c.SwaggerEndpoint("https://localhost:7209/swagger/v1/swagger.json", "Lead API");
        c.SwaggerEndpoint("http://localhost:5013/swagger/v1/swagger.json", "Knowledgebase API");
        c.SwaggerEndpoint("http://localhost:5001/swagger/v1/swagger.json", "Chat API");
        c.SwaggerEndpoint("http://localhost:5002/swagger/v1/swagger.json", "User API");
        c.SwaggerEndpoint("http://localhost:5014/swagger/v1/swagger.json", "Application API");
        c.SwaggerEndpoint("http://localhost:5010/swagger/v1/swagger.json", "College Info API");
        c.SwaggerEndpoint("http://localhost:5012/swagger/v1/swagger.json", "Lead API");

    });
}


app.MapReverseProxy();

app.Run();
