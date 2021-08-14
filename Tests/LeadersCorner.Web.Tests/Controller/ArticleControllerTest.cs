namespace LeadersCorner.Web.Tests
{
    using LeadersCorner.Data;
    using LeadersCorner.Data.Models;
    using LeadersCorner.Web.Controllers;
    using LeadersCorner.Web.ViewModels.Article;
    using Microsoft.EntityFrameworkCore;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class ArticleControllerTest
    {
        [Fact]
        public void ArticleCreateValidReturn()
        {

            var model = new Article
            {
                Id = 564,
                Title = "New article for time saving",
                CategoryId = 2,
                AuthorId = 2,
                ArticleContent = "The following artice is based on long researches..."
            };

            var optionBuilder = new DbContextOptionsBuilder<LeadersCornerDbContext>()

            .UseInMemoryDatabase("myDbContextForTest");

            var dbContext = new LeadersCornerDbContext(optionBuilder.Options);

            dbContext.Articles.Add(model);
            dbContext.SaveChanges();

            var controller = new CourseController(dbContext);

            Article result = dbContext.Articles.Find(564);

            Assert.NotNull(result);
            Assert.Equal("New article for time saving", result.Title);
        }

        [Fact]
        public void DetailsShouldReturnNotFoundWhenArticleIdIsInvalid()
            => MyController<ArticleController>
                .Instance()
                .WithUser()
                .Calling(c => c.Details(9.ToString()))
                .ShouldReturn()
                .View("_NotFound");

        [Fact]
        public void AllShouldReturnCorrectViewModel()
           => MyController<ArticleController>
               .Instance()
               .WithUser()
               .Calling(c => c.All(0, 0, 0))
               .ShouldReturn()
               .View(v => v
                   .WithModelOfType<AllArticleQueryModel>());

        [Fact]
        public void AllSortedShouldReturnCorrectViewModel()
       => MyController<ArticleController>
           .Instance()
           .WithUser()
           .Calling(c => c.All(0, 0,2))
           .ShouldReturn()
           .View(v => v
               .WithModelOfType<AllArticleQueryModel>());

        [Fact]
        public void AllCategoryTypeShouldReturnCorrectViewModel()
       => MyController<ArticleController>
           .Instance()
           .WithUser()
           .Calling(c => c.All(0, 1, 0))
           .ShouldReturn()
           .View(v => v
               .WithModelOfType<AllArticleQueryModel>());
        [Fact]
        public void AllCategoryAndSortingTypeShouldReturnCorrectViewModel()
       => MyController<ArticleController>
           .Instance()
           .WithUser()
           .Calling(c => c.All(0, 1, 2))
           .ShouldReturn()
           .View(v => v
               .WithModelOfType<AllArticleQueryModel>());
    }
}
