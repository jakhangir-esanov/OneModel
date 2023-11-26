using Microsoft.EntityFrameworkCore;
using OneModel.Entities;

namespace OneModel.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions) { }

    public DbSet<User> Users { get; set; }
}
