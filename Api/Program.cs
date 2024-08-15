using Api.Extensions;
using Infra.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddServices();
builder.Services.AddHttps(configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioningExtension();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
});
builder.Services.AddSwaggerOptions();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.AddSwaggerConfiguration();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
