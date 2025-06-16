var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
//if (app.Environment.IsDevelopment())

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/user/swagger/v1/swagger.json", "User API");
    c.SwaggerEndpoint("/lead/swagger/v1/swagger.json", "Lead API");
    c.SwaggerEndpoint("/collegeinfo/swagger/v1/swagger.json", "College Info API");

});

app.MapReverseProxy();

app.Run();
