using AspNetMvcMonolithic.Models.DomainModels.PersonAggregates;
using AspNetMvcMonolithic.Models.DomainModels.ProductAggregates;
using Microsoft.EntityFrameworkCore;

namespace AspNetMvcMonolithic.Models
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {

        }
        public DbSet<Person> Person { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
