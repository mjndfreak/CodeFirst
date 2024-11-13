using CodeFirst.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Data.Context;

public class CodeFirstDbContext : DbContext
{
    public CodeFirstDbContext(DbContextOptions<CodeFirstDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<MovieEntity> Movies => Set<MovieEntity>();
    public DbSet<GameEntity> Games => Set<GameEntity>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=CodeFirstDb1;Username=cagdasergenc;Password=cagdasergenc");
    }
}