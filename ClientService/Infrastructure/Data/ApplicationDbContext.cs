using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Data;
public class ApplicationDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.FullName).IsRequired().HasMaxLength(200);
            entity.Property(c => c.IdentificationDocument).IsRequired().HasMaxLength(50);
            entity.Property(c => c.Address).IsRequired().HasMaxLength(300);
            entity.Property(c => c.Status).IsRequired();
        });
    }
}