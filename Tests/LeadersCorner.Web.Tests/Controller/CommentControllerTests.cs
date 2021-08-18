namespace LeadersCorner.Web.Tests.Controller
{
    using LeadersCorner.Data;
    using LeadersCorner.Data.Models;
    using LeadersCorner.Services.Data;
    using LeadersCorner.Web.Controllers;
    using LeadersCorner.Web.ViewModels.Article;
    using LeadersCorner.Web.ViewModels.Comment;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MyTested.AspNetCore.Mvc;
    using System;
    using Xunit;

    public class CommentControllerTests
    {
        private readonly LeadersCornerDbContext data;
        private readonly ICommentService commentService;
        private readonly IDetailsService detailsService;
        private readonly IArticleService articleService;
        [Fact]
        public void CommentCreateValidReturn()
        {
            var model = new Comment
            {
                Id = 564,
                CommentContent = "Here",
            };

            var optionBuilder = new DbContextOptionsBuilder<LeadersCornerDbContext>()

            .UseInMemoryDatabase("myDbContextForTest");

            var dbContext = new LeadersCornerDbContext(optionBuilder.Options);

            dbContext.Comments.Add(model);
            dbContext.SaveChanges();

            Comment result = dbContext.Comments.Find(564);

            Assert.NotNull(result);
            Assert.Equal("Here", result.CommentContent);
        }
    }
}
