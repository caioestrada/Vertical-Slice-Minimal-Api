using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VerticalSliceMinimalApi.Database;

namespace VerticalSliceMinimalApi.Integration.Test
{
    public class IntegrationTestFactory
    {
        public readonly HttpClient _httpClient;
        public readonly AppDbContext _context;

        public IntegrationTestFactory()
        {
            var appFactory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(host =>
                {
                    host.ConfigureServices(services =>
                    {
                        var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<AppDbContext>));
                        services.Remove(descriptor);

                        services.AddDbContext<AppDbContext>(options =>
                        {
                            options.UseInMemoryDatabase("InMemoryDB");
                        });
                    });
                });

            var scope = appFactory.Services.GetService<IServiceScopeFactory>()!.CreateScope();
            _context = scope.ServiceProvider.GetService<AppDbContext>();
            _httpClient = appFactory.CreateClient();
        }
    }
}
