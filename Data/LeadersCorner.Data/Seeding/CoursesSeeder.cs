using LeadersCorner.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadersCorner.Data.Seeding
{
    class CoursesSeeder : ISeeder
    {
        public async Task SeedAsync(LeadersCornerDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Courses.Any())
            {
                return;
            }


            await dbContext.AddAsync(new Course
            {
                Title = "What Is Leadership?",
                CourseContent = "You will access unit and module overviews, assignment instructions, and course readings through " +
                "the Content area. To get there, click the “Content” link in the top navigation or use the Content panel in the left " +
                "on the class home page. Begin every unit and module by reading the unit " +
                "or module overview in Content. Check there for the the instructions for the activities and for readings. ",
                ImageUrl = "https://images.unsplash.com/photo-1541844053589-346841d0b34c?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MXx8bGVhZGVyc2hpcHxlbnwwfHwwfHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                DurationInWeeks = 9,
                AuthorId = 1,
                CategoryId = dbContext.Categories
                .Where(c => c.CategoryName == "WorkAthmosphere")
                .Select(c => c.Id)
                .FirstOrDefault(),
            });;
            await dbContext.AddAsync(new Course
            {
                Title = "How to be supportive in time of pressure",
                CourseContent = "During the next few weeeks we will be talking for the main .....",
                ImageUrl = "https://images.unsplash.com/photo-1553034545-32d4cd2168f1?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MXx8dGltZSUyMG1hbmFnZXxlbnwwfHwwfHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                DurationInWeeks = 5,
                AuthorId = 2,
                CategoryId = dbContext.Categories
                .Where(c => c.CategoryName == "TimeManagement")
                .Select(c => c.Id)
                .FirstOrDefault(),

            });;
            await dbContext.AddAsync(new Course
            {
                Title = "Bad apples",
                CourseContent = "Who is the bad apple at you team and how to deal with the situations...",
                ImageUrl = "https://images.unsplash.com/photo-1542014740373-51ad6425eb7c?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MXx8YmFkJTIwYXBwbGV8ZW58MHx8MHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                AuthorId = 2,
               DurationInWeeks = 2,
                CategoryId = dbContext.Categories
                .Where(c => c.CategoryName == "Recruiting")
                .Select(c => c.Id)
                .FirstOrDefault(),
            });
        }
       
    }
}
