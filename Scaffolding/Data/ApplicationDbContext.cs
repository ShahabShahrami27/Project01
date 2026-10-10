using Microsoft.EntityFrameworkCore;
using Scaffolding.Models.DomainModels.PersonAggregates;
using Scaffolding.Models.DomainModels.ProductAggregates;

namespace AspNetMvcMonolithic.Models
{
    public class ApplicationDbContext : DbContext
    {

        //Add Connection String
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Data Source=.;Initial Catalog=AspNetMvcMonolithic;Integrated Security=True;Persist Security Info=False;Trust Server Certificate=True;");
            }
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Product> Product { get; set; }


    }
}
