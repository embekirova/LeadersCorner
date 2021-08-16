namespace LeadersCorner.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using LeadersCorner.Data;
    using LeadersCorner.Data.Models;
    using LeadersCorner.Services.Data;
    using LeadersCorner.Web.Infrastructure;
    using LeadersCorner.Web.ViewModels.Article;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ArticleController : BaseController
    {
        private readonly LeadersCornerDbContext data;
        private readonly ICommentService commentService;
        private readonly IDetailsService detailsService;
        private readonly IArticleService articleService;

        public ArticleController(
            LeadersCornerDbContext data,
            ICommentService commentService,
            IDetailsService detailsService,
            IArticleService articleService)
        {
            this.data = data;
            this.commentService = commentService;
            this.detailsService = detailsService;
            this.articleService = articleService;
        }

        [Authorize]
        public IActionResult Create()
        {
            var categories = this.data
                .Categories.ToList();

            return this.View(new CreateArticleFormModel
            {
                Categories = categories,
            });
        }

        [HttpPost]
        [Authorize]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreateArticleFormModel article)
        {
            var userId = this.User.GetId();
            var userIsAnAuthor = this.data
                .Authors
                .Any(a => a.UserID == userId);

            var userIdentity = this.data
                .Authors
                .Where(c => c.UserID == userId)
                .FirstOrDefault();

            if (!userIsAnAuthor)
            {
                return this.BadRequest();
            }

            if (!this.data.Categories.Any(c => c.Id == c.Id))
            {
                this.ModelState.AddModelError(nameof(article.Id), "Category does not exist.");
            }

            if (!this.ModelState.IsValid)
            {
                var categories = this.data
                .Categories.ToList();

                return this.View(new CreateArticleFormModel
                {
                    Categories = categories,
                    Title = article.Title,
                    ArticleContent = article.ArticleContent,
                    ImageUrl = article.ImageUrl,
                    CategoryId = article.CategoryId,
                    Id = article.Id,
                    AuthorId = userIdentity.Id,
                });
            }

            var articleData = new Article(userIdentity.Id, article.Title)
            {
                Title = article.Title,
                ArticleContent = article.ArticleContent,
                ImageUrl = article.ImageUrl,
                CategoryId = article.CategoryId,
                Id = article.Id,
                AuthorId = userIdentity.Id,
            };

            this.data.Articles.Add(articleData);
            this.data.SaveChanges();

            return this.View("ArticleCreated");
        }

        public IActionResult All(int currentPage, int categoryId, int sorting)
        {
            var view = this.articleService.AllArticles(currentPage, categoryId, sorting);

            return this.View(view);
        }

        public async Task <IActionResult> Details(string id)
        {
            var idNumber = int.Parse(id);
            if (!this.data.Articles.Any(c => c.Id == idNumber))
            {
                return this.View("_NotFound");
            }

            var viewNodel = this.detailsService.Details(idNumber);
            return this.View(viewNodel);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteCommentAsync(int id)
        {
            var commentArticle = this.data.Comments.Find(id).ArticleID;
            var commentCours = this.data.Comments.Find(id).CourseId;

            await this.commentService.DeleteCommentAsync(id);

            if (commentArticle != null)
            {
                return this.RedirectToAction("Details", "Article", new { id = commentArticle });
            }
            else
            {
                return this.RedirectToAction("Details", "Course", new { id = commentCours });
            }
        }
    }
}
