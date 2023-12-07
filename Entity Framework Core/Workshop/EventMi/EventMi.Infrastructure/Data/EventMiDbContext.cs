using EventMi.Infrastructure.Configuration;
using EventMi.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace EventMi.Infrastructure.Data;

public class EventMiDbContext : DbContext
{
    public EventMiDbContext(DbContextOptions<EventMiDbContext> options)
        : base(options)
    {
    }

    public DbSet<Event> Events { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EventConfiguration());
    }
}