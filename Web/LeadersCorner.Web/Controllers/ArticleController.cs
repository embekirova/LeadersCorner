namespace LeadersCorner.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using LeadersCorner.Data;
    using LeadersCorner.Data.Common.Repositories;
    using LeadersCorner.Data.Models;
    using LeadersCorner.Web.Infrastructure;
    using LeadersCorner.Web.ViewModels;
    using LeadersCorner.Web.ViewModels.Article;
    using LeadersCorner.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class ArticleController : BaseController
    {
        private readonly ApplicationDbContext data;

        public ArticleController(
            ApplicationDbContext data)
        => this.data = data;

        [Authorize]
        public IActionResult Create() => this.View();


        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateArticleFormModel article)
        {
            var userId = this.User.GetId();
            var userIsAnAuthor = this.data
                .Authors
                .Any(a => a.UserID == userId);
            if (!userIsAnAuthor)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            int convertedUserId = int.Parse(userId);
            var articleData = new Article(int.Parse(userId), article.Title)
            {
                Title = article.Title,
                ArticleContent = article.ArticleContent,
                CategoriesOfArticle = article.CategoriesOfArticle,
            };

            this.data.Articles.Add(articleData);
            this.data.SaveChanges();

            return this.Redirect("/");
        }
    }
}
