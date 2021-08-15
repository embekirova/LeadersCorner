namespace LeadersCorner.Web.Controllers
{
    using System.Collections.Generic;
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
        private readonly ArticleSorting sortingType;
        private readonly IAuthorService authorsService;
        private readonly ICommentService commentService;
        private readonly IMapper mapper;

        public ArticleController(
            LeadersCornerDbContext data,
            ICommentService commentService)
        {
            this.data = data;
            this.commentService = commentService;
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

        public IActionResult All(int CurrentPage, int CategoryId, int Sorting)
        {
            if (CurrentPage == 0)
            {
                CurrentPage = 1;
            }
            var categories = this.data
                .Categories
                .ToList();

            var articleQuery = this.data.Articles.AsQueryable();
            var articles = new List<Article>();
            articles = this.data.Articles.ToList();

            if (Sorting != 0 && Sorting != 1 && Sorting == 2)
            {
                Sorting = 0;
            }

            var sortingType = (ArticleSorting)Sorting;
            articles = sortingType switch
            {
                ArticleSorting.DateCreated => articles.OrderByDescending(c => c.Id).ToList(),
                ArticleSorting.ReverseDateCreated => articles.OrderBy(c => c.Id).ToList(),
                ArticleSorting.NullValue or _ => articles.OrderByDescending(c => c.Id).ToList(),
            };

            if (CategoryId == 0)
            {
                articles = articles
               .Skip((CurrentPage - 1) * AllArticleQueryModel.ArticlesPerPage)
               .Take(AllArticleQueryModel.ArticlesPerPage)
               .OrderByDescending(article => article.Id)
               .ToList();
            }
            else
            {
                articles = articles
                    .Where(c => c.CategoryId == CategoryId)
                    .Skip((CurrentPage - 1) * AllArticleQueryModel.ArticlesPerPage)
                    .Take(AllArticleQueryModel.ArticlesPerPage)
                    .OrderByDescending(article => article.Id)
                    .ToList();
            }

            var totalArticles = articleQuery.Count();

            return this.View(new AllArticleQueryModel
            {
                CategoryId = CategoryId,
                Categories = categories,
                Articles = articles,
                Sorting = sortingType,
                CurrentPage = CurrentPage,
                TotalArticles = totalArticles,
            });
        }

        public IActionResult Details(string id)
        {
            var idNumber = int.Parse(id);
            if (!data.Articles.Any(c => c.Id == idNumber))
            {
                return this.View("_NotFound");
            }

            var comments = this.data
                .Comments
                .Where(c => c.ArticleID == idNumber)
                .ToList();

            var current =
                 this.data
                 .Articles
                 .Where(c => c.Id == int.Parse(id))
                 .FirstOrDefault();

            var currentArticle = new CurrentArticleViewModel()
            {
                Title = current.Title,
                ArticleContent = current.ArticleContent,
                ImageUrl = current.ImageUrl,
                Id = current.Id,
                AuthorId = current.AuthorId,
                Comments = comments,
            };

            return this.View(currentArticle);
        }

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