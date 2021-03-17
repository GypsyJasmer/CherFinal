using Microsoft.EntityFrameworkCore;

namespace CherFanPage.Models
{
    public class OutfitContext : DbContext
    {
        public OutfitContext(DbContextOptions<OutfitContext> options)
            : base(options)
        { }

        public DbSet<Outfit> Outfits { get; set; }
        public DbSet<OutfitYear> OutfitYears { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OutfitYear>().HasData(
                new OutfitYear { OutfitYearID = "1960", Decade = "1960"},
                new OutfitYear { OutfitYearID = "1970", Decade = "1970" },
                new OutfitYear { OutfitYearID = "1980", Decade = "1980" }  
            );

            modelBuilder.Entity<Outfit>().HasData(
               new {OutfitId = "JC", Title = "Just Cher", Decade="1960's", LogoImage = "~/FavOutfits/1960JustCher.png" },
               new { OutfitId = "SC", Title = "Sonny & Cher", Decade = "1960's", LogoImage = "~/FavOutfits/1960SonnynCher.png" },
               new { OutfitId = "HB", Title = "Half Breed", Decade = "1970's", LogoImage = "~/FavOutfits/1970HalfBreed.png" },
               new { OutfitId = "D1", Title = "Disco 1", Decade = "1970's", LogoImage = "~/FavOutfits/1970Part2.png" },
               new { OutfitId = "D2", Title = "Egypt Cher", Decade = "1970's", LogoImage = "~/FavOutfits/1970Random.png" },
               new { OutfitId = "D3", Title = "Take Me Home", Decade = "1970's", LogoImage = "~/FavOutfits/1970TakeMeHome.png" },
               new { OutfitId = "A1", Title = "Award #1", Decade = "1980's", LogoImage = "~/FavOutfits/1980Award1.png" },
               new { OutfitId = "A2", Title = "Bob Mackey", Decade = "1980's", LogoImage = "~/FavOutfits/1980BobM.png" },
               new { OutfitId = "2000", Title = "Current Tour Cher", Decade = "2000's", LogoImage = "~/FavOutfits/2000FB.png" }

            );
        }
    }
}
