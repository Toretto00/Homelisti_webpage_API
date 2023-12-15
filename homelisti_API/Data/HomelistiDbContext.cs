using homelisti_API.Models.Domain;
using Microsoft.EntityFrameworkCore;


namespace homelisti_API.Data
{
    public class HomelistiDbContext: DbContext
    {
        public HomelistiDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        { 
        
        }

        public DbSet<ListingTypes> ListingTypes { get; set; }

        public DbSet<Categories> Categories { get; set; }

        public DbSet<Locations> Locations { get; set; }

        public DbSet<Listings> Listings { get; set; }
    }
}
