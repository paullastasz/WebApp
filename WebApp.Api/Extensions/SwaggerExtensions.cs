namespace WebApp.Api
{
    public static class SwaggerExtensions
    {
        public static void UseSwaggerExtension(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }
        public static void UseSwaggerEndpointExtension(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(swagger =>
                {
                    swagger.RoutePrefix = "swagger";

                    swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "API Documentation - version 1");

                    //HttpFilesGenerator.RegenerateHttpFiles(typeof(Program).Assembly);

                });
            }
        }
    }
}
