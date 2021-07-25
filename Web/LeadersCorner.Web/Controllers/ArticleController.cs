namespace LeadersCorner.Web.Controllers
{
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    using LeadersCorner.Data;
    using LeadersCorner.Data.Common.Repositories;
    using LeadersCorner.Data.Models;
    using LeadersCorner.Web.Infrastructure;
    using LeadersCorner.Web.ViewModels;
    using LeadersCorner.Web.ViewModels.Article;
    using LeadersCorner.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class ArticleController : BaseController
    {
        private readonly LeadersCornerDbContext data;
        
        public ArticleController(
            LeadersCornerDbContext data)
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

           if (!(article.Image.FileName.EndsWith(".png") & article.Image.FileName.EndsWith(".jpeg")))
            {
                this.ModelState.AddModelError("Image", "Invalid file type");
            }

            using (FileStream fs = new FileStream(
                "C:/Users/Lenovo/Desktop/LeadersCorner/Web/LeadersCorner.Web/Files" + "/user.png", FileMode.Create))
            {
                article.Image.CopyTo(fs);
            } ;
            
            
            var articleData = new Article(userId, article.Title)
            {
                Title = article.Title,
                ArticleContent = article.ArticleContent,
                Categories = article.Categories,
            };

            this.data.Articles.Add(articleData);
            this.data.SaveChanges();

            return View("ArticleCreated");
        }
    }
}
