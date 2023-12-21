using VerticalSliceMinimalApi.Features.Todo;

namespace VerticalSliceMinimalApi.Database
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<TodoEntity> Todos { get; set; } = null!;
    }
}