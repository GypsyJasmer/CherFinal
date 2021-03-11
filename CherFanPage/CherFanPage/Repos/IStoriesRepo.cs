using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CherFanPage.Models;
using CherFanPage.Repos;
using Microsoft.EntityFrameworkCore;

namespace CherFanPage.Repos
{
    public interface IStoriesRepo
    {
        IQueryable<StoryModel> Stories { get; }  // Read (or retrieve) Story

        //IQueryable<StoryModel> Date { get; }       // retrieve message by date

        StoryModel GetStoryByTitle(string title);  // Retrieve a particular story

        void AddStory(StoryModel story);  // Create a story

        void UpdateStory(StoryModel story);

        List<StoryModel> GetAllStories();

        StoryModel GetOneStory_byID(int ID);

        public void SaveChanges();
     


    }
}
