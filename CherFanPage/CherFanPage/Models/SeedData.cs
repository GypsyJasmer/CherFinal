using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace CherFanPage.Models
{
    public class SeedData
    {
        public static void Seed(StoriesContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
           if (!context.Stories.Any())  // this is to prevent adding duplicate data
            {
                //this makes sure that db is created. 
                context.Database.EnsureCreated();

                //create member role
                var result = roleManager.CreateAsync(new IdentityRole("Member")).Result;
                result = roleManager.CreateAsync(new IdentityRole("Admin")).Result;

                /***********************Seeding a default administrator. They will need to change their password after logging in.*****************/
                
                AppUser siteadmin = new AppUser
                {
                    UserName = "SiteAdmin",
                    Name = "Site Admin"
                };

                userManager.CreateAsync(siteadmin, "Secret-123").Wait();
                IdentityRole adminRole = roleManager.FindByNameAsync("Admin").Result;
                userManager.AddToRoleAsync(siteadmin, adminRole.Name); 
                
                

                /******************User1****************/
                AppUser emmaWatson = new AppUser 
                {
                    UserName = "EWatson",
                    Name = "Emma Watson" 
                };
                context.Users.Add(emmaWatson);
                context.SaveChanges(); // stores all the reviews in the DB

                StoryModel story = new StoryModel

                {
                    Title = "Cher's 1st Farewell Tour",
                    StoryText = "I was so happy to see Cher one more time before she retired?",
                    Submitter = emmaWatson,
                    DateSubmitted = DateTime.Parse("11/1/2020")
                };

                context.Stories.Add(story);  // queues up a review to be added to the DB

                /******************User2****************/
                AppUser dwayneJohnson = new AppUser 
                {
                    UserName = "TheRock",
                    Name = "Dwayne Johnson" 
                };
                context.Users.Add(dwayneJohnson);
                context.SaveChanges(); // stores all the reviews in the DB

                story = new StoryModel
                {
                    Title = "Cher's 2nd Farewell Tour",
                    StoryText = "I was so happy to see Cher one more time before she retired?",
                    Submitter = dwayneJohnson,
                    DateSubmitted = DateTime.Parse("11/1/2020")
                 };

                context.Stories.Add(story);

                /******************User3****************/

                AppUser submitterSandiJasmer = new AppUser
                {
                    UserName = "Sandos",
                    Name = "Sandi Jasmer" ,               
                };
                context.Users.Add(submitterSandiJasmer);
                context.SaveChanges();   // This will add a UserID to the reviewer object

                story = new StoryModel
                {
                    Title = "Cher's 3rd Farewell Tour",
                    StoryText = "I was so happy to see Cher one more time before she retired?",
                    Submitter = submitterSandiJasmer,
                    DateSubmitted = DateTime.Parse("11/1/2020")
                };
                context.Stories.Add(story);


                context.SaveChanges(); // stores all the reviews in the DB

                /**For Outfits**/

                OutfitYear oy = new OutfitYear { OutfitYearID = "1960", Decade = "1960" };
                context.OutfitYear.Add(oy);
                OutfitYear georgia = new OutfitYear { OutfitYearID = "1970", Decade = "1970" };
                context.OutfitYear.Add(georgia);
                OutfitYear miss = new OutfitYear { OutfitYearID = "1980", Decade = "1980" };
                context.OutfitYear.Add(miss);

                context.SaveChanges();

                Outfit JC=new Outfit{ OutfitID = "JC", Title = "Just Cher",  LogoImage = "1960JustCher.png" };
                context.Outfits.Add(JC);
                context.SaveChanges();
                //new { OutfitID = "SC", Title = "Sonny & Cher", Decade = "1960's", LogoImage = "1960SonnynCher.png" };
                //new { OutfitID = "HB", Title = "Half Breed", Decade = "1970's", LogoImage = "1970HalfBreed.png" };
                //new { OutfitID = "D1", Title = "Disco 1", Decade = "1970's", LogoImage = "1970Part2.png" };
                //new { OutfitID = "D2", Title = "Egypt Cher", Decade = "1970's", LogoImage = "1970Random.png" };
                //new { OutfitID = "D3", Title = "Take Me Home", Decade = "1970's", LogoImage = "1970TakeMeHome.png" };
                // new { OutfitID = "A1", Title = "Award #1", Decade = "1980's", LogoImage = "1980Award1.png" };
                //new { OutfitID = "A2", Title = "Bob Mackey", Decade = "1980's", LogoImage = "1980BobM.png" };
                // new { OutfitID = "2000", Title = "Current Tour Cher", Decade = "2000's", LogoImage = "2000FB.png" };





            }

}

    }
}

