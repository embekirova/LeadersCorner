namespace LeadersCorner.Web.Controllers
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using LeadersCorner.Data;
    using LeadersCorner.Data.Common.Repositories;
    using LeadersCorner.Data.Models;
    using LeadersCorner.Web.Infrastructure;
    using LeadersCorner.Web.ViewModels;
    using LeadersCorner.Web.ViewModels.Author;
    using LeadersCorner.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class AuthorController : BaseController
    {
        private readonly LeadersCornerDbContext data;

       

        public AuthorController(
            LeadersCornerDbContext data)
        => this.data = data;

        [Authorize]
        public IActionResult Become() => this.View();


        [HttpPost]
        [Authorize]
        public IActionResult Become(CreateArticleFormModel author)
        {
            var userId = this.User.GetId();
            var userIsAnAuthor = this.data
                .Authors
                .Any(a => a.UserID == userId);
            if (userIsAnAuthor)
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var authoraData = new Author
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                UserID = userId,
            };

            this.data.Authors.Add(authoraData);
            this.data.SaveChanges();

            return View("LoggedAuthor");
        }

        public IActionResult All() => this.View();
    }
}
