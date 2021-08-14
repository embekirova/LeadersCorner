namespace LeadersCorner.Web.Controllers
{
    using LeadersCorner.Data;
    using LeadersCorner.Data.Models;
    using LeadersCorner.Web.Infrastructure;
    using LeadersCorner.Web.ViewModels.Author;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class AuthorController : BaseController
    {
        private readonly LeadersCornerDbContext data;
        public AuthorController(
            LeadersCornerDbContext data)
        => this.data = data;

        [Authorize]
        public IActionResult Become()
        {
            var userId = this.User.GetId();
            var userIsAnAuthor = this.data
                .Authors
                .Any(a => a.UserID == userId);

            if (userIsAnAuthor)
            {
                return this.View("AlreadyAnAuthor");
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        [AutoValidateAntiforgeryToken]
        public IActionResult Become(BecomeAuthorFormModel author)
        {
            var userId = this.User.GetId();
            var userIsAnAuthor = this.data
                .Authors
                .Any(a => a.UserID == userId);

            if (userIsAnAuthor)
            {
                return this.View("AlreadyAnAuthor");
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
