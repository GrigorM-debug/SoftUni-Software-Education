using EventMI.Infrastructure.Configuration;
using EventMI.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace EventMI.Infrastructure.Data;

public class EventMIDbContext : DbContext
{
    public EventMIDbContext(DbContextOptions<EventMIDbContext> options)
        : base(options)
    {
    }

    public DbSet<Event> Events { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EventConfiguration());
    }
}