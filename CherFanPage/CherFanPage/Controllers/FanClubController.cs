using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using CherFanPage.Models;
using CherFanPage.Repos;
using CherFanPage.Models.DM;
using Telerik.Web.Mvc.Extensions;



namespace CherFanPage.Controllers
{
    public class FanClubController : Controller
    {
        //field
        //StoriesContext context;
        IStoriesRepo repo;
        UserManager<AppUser> userManager;

        public FanClubController(IStoriesRepo r, UserManager<AppUser> u)
        {
            //object being passed in and assigning it. 
            repo = r;
            //Getting the object from DI
            userManager = u;
        }

        /***************CONTROLLER VIEWS************/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Timeline()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        /*************** Quiz**********/

        [HttpGet]
        public IActionResult Quiz()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Quiz(QuizVM quiz)
        {
            quiz.CheckAnswers();
            return View(quiz);
        }


        /*************** SUBMITTING A STORY**********/
        [Authorize]
        public IActionResult Stories()
        {/*
            StoriesModels model = new StoriesModels();
            user submitter = new user();
            model.Submitter = submitter;
            */
            return View();
        }

        [HttpPost]
        public IActionResult Stories(StoryModel model)
        {
            if (ModelState.IsValid)
            {
                model.Submitter = userManager.GetUserAsync(User).Result; //returns an identity user object. 
                                                                         //Submitter is an appuser object is a identity user object. 

                // TODO: get the user's real name in registration
                model.Submitter.Name = model.Submitter.UserName;  // temporary hack shows username when they submitt a story. 
                model.DateSubmitted = DateTime.Now;

                // Store the model in the database
                repo.AddStory(model);

            }

            return View(model);
        }

        /***********SEE ALL STORIES SUBMITTED METHODS******************/
        [HttpPost]
        public IActionResult AllStories(string storyTitle, string SubmitterName)
        {
            List<StoryModel> stories = null;

            if (storyTitle != null)
            {
                stories = (from r in repo.Stories
                           where r.Title == storyTitle
                           select r).ToList();
            }

            else if (SubmitterName != null)
            {
                stories = (from r in repo.Stories
                           where r.Submitter.Name == SubmitterName
                           select r).ToList();
            }

            return View(stories);
        }


        //this method will send data to the webpage
        public IActionResult AllStories()
        {
            //pulling a list of all stories out of the DB
            //Putting them into a list of stories 
            //Mesenger comes from Message model, it is the User FK
            //var allStories = context.Stories.Include(allStories=>allStories.Submitter).ToList<StoryModel>();
            List<StoryModel> allStories = repo.Stories.ToList<StoryModel>();//Submitter comes from StoryModel model, it is the User FK
            //sent to a new view (to be created)
            return View(allStories);

        }


        /*****************COMMENT METHODS*******************/
        // bring up the form for entering a comment
        [Authorize] //allows the user to not open form unless logged in
        [HttpGet]
        public IActionResult Comment(int storyID)
        {
            var commentVM = new CommentVM { StoryID = storyID };
            return View(commentVM);

        }

        // gets the data back from the form 
        [HttpPost]
        public RedirectToActionResult Comment(CommentVM commentVM)
        {
            // Comment is the domain model 
            var comment = new Comment { CommentText = commentVM.CommentText }; // User input
            comment.Commenter = userManager.GetUserAsync(User).Result; // Get user from UserManager
            comment.Commenter.Name = comment.Commenter.UserName;
            comment.CommentDate = DateTime.Now;

            // Retrieve the story the comment is for
            var story = (from r in repo.Stories
                         where r.StoryID == commentVM.StoryID
                         select r).First<StoryModel>();

            // Store the message with the comment in the database
            story.Comments.Add(comment);
            repo.UpdateStory(story);

            return RedirectToAction("allStories");
        }



        /*****************Timeline METHODS*******************/
        public JsonResult GetTimelineData()
        {
            List<TimelineModel> events = new List<TimelineModel>();

            events.Add(new TimelineModel()
            {
                Title = "Barcelona \u0026 Tenerife",
                Subtitle = "May 15, 2015",
                Description = "First event description.",
                EventDate = new System.DateTime(2015, 4, 15),

                Actions = new List<TimelineEventAction>() {
                new TimelineEventAction() { text = "More info about Barcelona", url="https://en.wikipedia.org/wiki/Barcelona" }
            }
            });

            events.Add(new TimelineModel()
            {
                Title = "United States East Coast Tour",
                Subtitle = "Feb 27, 2018",
                Description = "The second event description.",
                EventDate = new System.DateTime(2018, 1, 27),

                Actions = new List<TimelineEventAction>() {
                new TimelineEventAction() { text = "More info about New York City", url="https://en.wikipedia.org/wiki/New_York_City" }
            }
            });

            events.Add(new TimelineModel()
            {
                Title = "Malta, a Country of Кnights",
                Subtitle = "My second trip this year",
                Description = "Third event description.",
                EventDate = new System.DateTime(2015, 5, 25),

                Actions = new List<TimelineEventAction>() {
                new TimelineEventAction() { text = "More info about Malta", url="https://en.wikipedia.org/wiki/Malta" }
            }
            });


            return Json(events);
        }
    }

}


