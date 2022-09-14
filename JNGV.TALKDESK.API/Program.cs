using JNGV.TALKDESK.API.Repository;
using JNGV.TALKDESK.API.Services;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IApiService, ApiService>();
builder.Services.AddTransient<IApiRepository, ApiRepository>();
builder.Services.AddTransient<IHttpService, HttpService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHttpClient();

builder.Services.Configure<IISOptions>(options =>
{
    options.ForwardClientCertificate = false;
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "JNGV.TALKDESK API",
        Version = "v1",
        Description = @"<br>API exercise by João Veloso</br>"



    });
});

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(o =>
{
    o.AddPolicy(MyAllowSpecificOrigins, builder =>
    {
        builder.WithOrigins("http://localhost:8080/", "https://localhost:8080/")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TALKDESKAPI");
        c.RoutePrefix = string.Empty;
    });
}






app.UseRouting();


//app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
