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
                Outfit SC = new Outfit { OutfitID = "SC", Title = "Sonny & Cher",  LogoImage = "1960SonnynCher.png" };
                context.Outfits.Add(SC);
                context.SaveChanges();
                Outfit HB = new Outfit { OutfitID = "HB", Title = "Half Breed",  LogoImage = "1970HalfBreed.png" };
                context.Outfits.Add(HB);
                context.SaveChanges();
                Outfit D1 = new Outfit { OutfitID = "D1", Title = "Disco 1",  LogoImage = "1970Part2.png" };
                context.Outfits.Add(D1);
                context.SaveChanges();
                Outfit D2 = new Outfit { OutfitID = "D2", Title = "Egypt Cher",  LogoImage = "1970Random.png" };
                context.Outfits.Add(D2);
                context.SaveChanges();
                Outfit D3 = new Outfit { OutfitID = "D3", Title = "Take Me Home",  LogoImage = "1970TakeMeHome.png" };
                context.Outfits.Add(D3);
                context.SaveChanges();
                Outfit A1 = new Outfit { OutfitID = "A1", Title = "Award #1",  LogoImage = "1980Award1.png" };
                context.Outfits.Add(A1);
                context.SaveChanges();
                Outfit A2 = new Outfit { OutfitID = "A2", Title = "Bob Mackey",  LogoImage = "1980BobM.png" };
                context.Outfits.Add(A2);
                context.SaveChanges();
                Outfit B1 = new Outfit { OutfitID = "B1", Title = "Current Tour Cher",  LogoImage = "2000FB.png" };
                context.Outfits.Add(B1);
                context.SaveChanges();





            }

}

    }
}

