using DjurApiLiveDemo.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace DjurApiLiveDemo.DataAccess;

public class PetOwnershipDbContext : DbContext
{
    public DbSet<Person> People { get; set; }
    public DbSet<Pet> Pets { get; set; }

    public PetOwnershipDbContext(DbContextOptions options) : base(options)
    {
        
    }
}