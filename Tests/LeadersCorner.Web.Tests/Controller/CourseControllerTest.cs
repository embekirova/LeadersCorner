namespace LeadersCorner.Web.Tests
{
    using System;

    using LeadersCorner.Data;
    using LeadersCorner.Data.Models;
    using LeadersCorner.Web.Controllers;
    using LeadersCorner.Web.ViewModels.Course;
    using Microsoft.EntityFrameworkCore;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class CourseControllerTest
    {
        private LeadersCornerDbContext data;

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
                CourseContent = "The course will be set at every Monday at 6.00 p.m. for the next 3 week...",
            };

            var optionBuilder = new DbContextOptionsBuilder<LeadersCornerDbContext>()

            .UseInMemoryDatabase("myDbContextForTest");

            var dbContext = new LeadersCornerDbContext(optionBuilder.Options);

            dbContext.Courses.Add(model);
            dbContext.SaveChanges();

            Course result = dbContext.Courses.Find(564);

            Assert.NotNull(result);
            Assert.Equal("New course for you", result.Title);
        }

        [Fact]
        public void CreateCourseShouldReturnView()
        {
            MyController<CourseController>
               .Calling(c => c.Create())
               .ShouldReturn()
               .View(v => v
              .WithModelOfType<CreateCourseFormModel>());
        }

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

        [Fact]
        public void ModelCouldnotBeNullOrEmpty()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                Course course = new Course();
                this.data.Courses.Add(course);
                this.data.SaveChanges();
            });
        }

        [Fact]
        public void DetailsProperly()
            => MyController<CourseController>
                .Instance(instance => instance
                    .WithData(TestData.GetCourse(1)))
                .Calling(c => c.Details("1"))
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<CurrentCourseViewModel>()
                    .Passing(article => article.Id == 1));
    }
}
