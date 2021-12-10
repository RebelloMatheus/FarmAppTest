namespace Microsoft.AspNetCore.Builder
{
    public static class RouteBuilderExtensions
    {
        public static void AdicionarSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger(x =>
            {
                x.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(x =>
            {
                x.RoutePrefix = string.Empty;
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Interface padrão swagger");
            });
        }
    }
}