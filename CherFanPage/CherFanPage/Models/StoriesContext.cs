using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CherFanPage.Models
{
    public class StoriesContext : IdentityDbContext
    {
        public StoriesContext(

           DbContextOptions<StoriesContext> options) : base(options) { }

        public DbSet<StoryModel> Stories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        // public DbSet<AppUser> Users { get; set; }

        public DbSet<Outfit> Outfits { get; set; }
        public DbSet<OutfitYear> OutfitYear { get; set; }




    }


}
