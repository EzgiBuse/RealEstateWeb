using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RealEstateWeb.Models;

namespace RealEstateWeb.Data
{
    public class ApplicationDbContext :IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<LocalUser> LocalUsers { get; set; }
        public DbSet<Estate> Estates { get; set; }
        public DbSet<EstateNumber> EstateNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Estate>().HasData(
                new Estate
                {
                    ID = 1,
                    Name = "Berlin Villa",
                    Details = "top floor home with a nice view",
                    ImageURL = "images/home/slide1.jpg",
                    Occupancy = 6,
                    Rate = 200,
                    Msq = 500,
                },
                 new Estate
                 {
                     ID = 2,
                     Name = "Munich Apartment",
                     Details = "Top floor apartment with a balcony",
                     ImageURL = "images/home/slide2.jpg",
                     Occupancy = 2,
                     Rate = 100,
                     Msq = 100,
                 },
                  new Estate
                  {
                      ID = 3,
                      Name = "Munich Villa for Family",
                      Details = "Family home with a garden",
                      ImageURL = "images/villa/villa1.jpg",
                      Occupancy = 1,
                      Rate = 50,
                      Msq = 100,
                  },
                   new Estate
                   {
                       ID = 4,
                       Name = "Canada House in Toronto",
                       Details = "Furnished house for small families",
                       ImageURL = "images/villa/villa2.jpg",
                       Occupancy = 5,
                       Rate = 600,
                       Msq = 400,
                   },
                   new Estate
                   {
                       ID = 5,
                       Name = "Düsseldorf Old Town House",
                       Details = "Next to the shopping district",
                       ImageURL = "images/villa/villa3.jpg",
                       Occupancy = 12,
                       Rate = 1200,
                       Msq = 600,
                   },
                   new Estate
                   {
                       ID = 6,
                       Name = "Essen Modern Villa",
                       Details = "Newly decorated Villa in Essen",
                       ImageURL = "images/villa/villa4.jpg",
                       Occupancy = 3,
                       Rate = 700,
                       Msq = 600,
                   },
                   new Estate
                   {
                       ID = 7,
                       Name = "Essen Tiny Villa",
                       Details = "Minimalist Villa in Essen",
                       ImageURL = "images/villa/villa5.jpg",
                       Occupancy = 2,
                       Rate = 400,
                       Msq = 120,
                   }

                );
        }
    }
}
