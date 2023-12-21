using Asp.Versioning;

namespace VerticalSliceMinimalApi.Configurations
{
    public static class ApiVersionConfiguration
    {
        public static void AddApiVersion(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });
        }
    }
}
