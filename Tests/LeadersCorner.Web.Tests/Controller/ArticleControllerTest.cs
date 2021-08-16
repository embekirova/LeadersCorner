namespace LeadersCorner.Web.Tests
{
    using System;

    using LeadersCorner.Data;
    using LeadersCorner.Data.Models;
    using LeadersCorner.Services.Data;
    using LeadersCorner.Web.Controllers;
    using LeadersCorner.Web.ViewModels.Article;
    using Microsoft.EntityFrameworkCore;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class ArticleControllerTest
    {
        private readonly LeadersCornerDbContext data;
        private readonly ICommentService commentService;
        private readonly IDetailsService detailsService;
        private readonly IArticleService articleService;

        [Fact]
        public void ArticleCreateValidReturn()
        {
            var model = new Article
            {
                Id = 564,
                Title = "New article for time saving",
                CategoryId = 2,
                AuthorId = 2,
                ArticleContent = "The following artice is based on long researches...",
            };

            var optionBuilder = new DbContextOptionsBuilder<LeadersCornerDbContext>()

            .UseInMemoryDatabase("myDbContextForTest");

            var dbContext = new LeadersCornerDbContext(optionBuilder.Options);

            dbContext.Articles.Add(model);
            dbContext.SaveChanges();

            var controller = new ArticleController(dbContext, this.commentService, this.detailsService, this.articleService);

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
           .Calling(c => c.All(0, 0, 2))
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

        [Fact]
        public void CreateArticleShouldReturnView()
        {
            MyController<ArticleController>
               .Calling(c => c.Create())
               .ShouldReturn()
               .View(v => v
              .WithModelOfType<CreateArticleFormModel>());
        }

        [Fact]
        public void ArticleCouldnotBeNullOrEmpty()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                Article article = new Article();
                this.data.Articles.Add(article);
                this.data.SaveChanges();
            });
        }

        [Fact]

        public void ModelCouldnotBeNullOrEmpty()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                Article article = new Article();
                this.data.Articles.Add(article);
                this.data.SaveChanges();
            });
        }

        [Fact]
        public void DetailsShouldReturnNotFoundWhenInvalidArticleId()
          => MyController<ArticleController>
              .Calling(c => c.Details("5666666"))
              .ShouldReturn()
              .View("_NotFound");

        [Fact]
        public void DetailsShouldReturnViewWithCorrectModelWhen()
            => MyController<ArticleController>
                .Instance(instance => instance
                    .WithUser("NonAuthor")
            .WithData(TestData.GetArticles(1)))
                .Calling(c => c.Details("1"))
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<CurrentArticleViewModel>()
                    .Passing(article => article.Id == 1));

        [Fact]
        public void CreateGetShouldHaveRestrictionsForHttpGetOnlyAndAuthorizedUsersAndShouldReturnView()
           => MyController<ArticleController>
               .Calling(c => c.Create())
               .ShouldHave()
               .ActionAttributes(attrs => attrs
                   .RestrictingForHttpMethod(HttpMethod.Post)
                   .RestrictingForAuthorizedRequests())
               .AndAlso()
               .ShouldReturn()
               .View();

        [Fact]
        public void DetailsProperly()
            => MyController<ArticleController>
                .Instance(instance => instance
                    .WithData(TestData.GetArticles(1)))
                .Calling(c => c.Details("1"))
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<CurrentArticleViewModel>()
                    .Passing(article => article.Id == 1));

        [Fact]
        public void CreatePostShouldHaveRestrictionsForHttpPostOnlyAndAuthorizedUsers()
           => MyController<ArticleController>
               .Calling(c => c.Create(With.Default<CreateArticleFormModel>()))
               .ShouldHave()
               .ActionAttributes(attrs => attrs
                   .RestrictingForHttpMethod(HttpMethod.Post)
                   .RestrictingForAuthorizedRequests());

        [Fact]
        public void CreatePostShouldReturnViewWithSameModelWhenInvalidModelState()
          => MyController<ArticleController>
              .Calling(c => c.Create(With.Default<CreateArticleFormModel>()))
              .ShouldHave()
              .InvalidModelState()
              .AndAlso()
              .ShouldReturn()
              .View(With.Default<CreateArticleFormModel>());
    }
}
