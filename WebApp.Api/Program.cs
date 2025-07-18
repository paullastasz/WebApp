using NewsPortalCMS.Application.Configuration;
using WebApp.Api;
using WebApp.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
    
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddAppliactionsServices();

builder.UseSwaggerExtension();

var app = builder.Build();

app.UseRouting();

app.UseSwaggerEndpointExtension();

app.MapControllers();

app.Run();
