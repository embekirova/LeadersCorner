namespace LeadersCorner.Web.Tests
{
    using LeadersCorner.Data;
    using LeadersCorner.Data.Models;
    using LeadersCorner.Web.Controllers;
    using LeadersCorner.Web.ViewModels.Course;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class CourseControllerTest
    {
        [Fact]
        public void CourseCreateValidReturn()
        {

            var model = new Course
            {
                Id = 564,
                Title = "New course for you",
                DurationInWeeks = 3,
                CategoryId = 2,
                AuthorId = 2,
                CourseContent = "The course will be set at every Monday at 6.00 p.m. for the next 3 week..."
            };

            var optionBuilder = new DbContextOptionsBuilder<LeadersCornerDbContext>()

            .UseInMemoryDatabase("myDbContextForTest");

            var dbContext = new LeadersCornerDbContext(optionBuilder.Options);

            dbContext.Courses.Add(model);
            dbContext.SaveChanges();

            var controller = new CourseController(dbContext);

            Course result = dbContext.Courses.Find(564);

            Assert.NotNull(result);
            Assert.Equal("New course for you", result.Title);
        }

        [Fact]
        public void CreateShouldHaveRestrictionsForAuthorizedUsers()
            => MyController<CourseController>
                .Calling(c => c.Details(1.ToString()))
                .ShouldHave()
                .ActionAttributes(attr => attr
                    .RestrictingForAuthorizedRequests());
         
        [Fact]

        public void DetailsCourseShouldReturnView()
            => MyController<CourseController>
                .Calling(c => c.Details(1.ToString()))
                .ShouldReturn()
                .View(v => v
               .WithModelOfType<CurrentCourseViewModel>());


        [Fact]
        public void DetailsShouldReturnNotFoundWhenArticleIdIsInvalid()
        => MyController<CourseController>
            .Instance()
            .WithUser()
            .Calling(c => c.Details(9.ToString()))
            .ShouldReturn()
            .View("_NotFound");

        [Fact]
        public void AllShouldReturnCorrectViewModel()
       => MyController<CourseController>
           .Instance()
           .WithUser()
           .Calling(c => c.All(0, 0, 0))
           .ShouldReturn()
           .View(v => v
               .WithModelOfType<AllCourseQueryModel>());

        [Fact]
        public void AllSortedShouldReturnCorrectViewModel()
       => MyController<CourseController>
           .Instance()
           .WithUser()
           .Calling(c => c.All(0, 0, 2))
           .ShouldReturn()
           .View(v => v
               .WithModelOfType<AllCourseQueryModel>());

        [Fact]
        public void AllCategoryTypeShouldReturnCorrectViewModel()
       => MyController<CourseController>
           .Instance()
           .WithUser()
           .Calling(c => c.All(0, 1, 0))
           .ShouldReturn()
           .View(v => v
               .WithModelOfType<AllCourseQueryModel>());
        [Fact]
        public void AllCategoryAndSortingTypeShouldReturnCorrectViewModel()
       => MyController<CourseController>
           .Instance()
           .WithUser()
           .Calling(c => c.All(0, 1, 2))
           .ShouldReturn()
           .View(v => v
               .WithModelOfType<AllCourseQueryModel>());
    }
}
