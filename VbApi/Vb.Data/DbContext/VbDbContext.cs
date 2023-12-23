using Microsoft.EntityFrameworkCore;
using Vb.Data.Entity;

namespace Vb.Data;

public class VbDbContext : DbContext
{
    public VbDbContext(DbContextOptions<VbDbContext> options): base(options)
    {
    
    }   
    
    // dbset 
    public DbSet<Customer> Customers { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AddressConfiguration());
        modelBuilder.ApplyConfiguration(new ContactConfiguration());
        base.OnModelCreating(modelBuilder);
    }
    
}