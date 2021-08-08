namespace LeadersCorner.Web.Controllers
{
    using System;
    using System.Collections.Generic;
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
    using Microsoft.AspNetCore.Http.Extensions;

    public class ArticleController : BaseController
    {
        private readonly LeadersCornerDbContext data;
        private readonly ArticleSorting sorting;

        public ArticleController(
            LeadersCornerDbContext data)
        => this.data = data;

        [Authorize]
        public IActionResult Create()
        {
            var categories = this.data
                .Categories.ToList();

            return this.View(new CreateCommentFormModel
            {
                Categories = categories,
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateCommentFormModel article)
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
                return this.View(article);
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

        public IActionResult All(AllArticleQueryModel articlModel)
        {
            var categories = this.data
                .Categories
                .ToList();

            var articleQuery = this.data.Articles.AsQueryable();
            var articles = new List<Article>();


            if (articlModel.CategoryId == 0)
            {
                articles = this.data
               .Articles
               .Skip((articlModel.CurrentPage - 1) * AllArticleQueryModel.ArticlesPerPage)
               .Take(AllArticleQueryModel.ArticlesPerPage)
               .OrderByDescending(article => article.Id)
               .ToList();
            }
            else
            {
                articles = this.data
                    .Articles
                    .Where(c => c.CategoryId == articlModel.CategoryId)
                    .Skip((articlModel.CurrentPage - 1) * AllArticleQueryModel.ArticlesPerPage)
                    .Take(AllArticleQueryModel.ArticlesPerPage)
                    .OrderByDescending(article => article.Id)
                    .ToList();
            }

            var totalArticles = articleQuery.Count();

            articles = this.sorting switch
            {
                ArticleSorting.DateCreated => articles.OrderByDescending(article => article.Id).ToList(),
                ArticleSorting.ReverseDateCreated => articles.OrderBy(c => c.Id).ToList(),
                ArticleSorting.NullValue => articles.OrderBy(c => Guid.NewGuid()).ToList(),
                _ => articles.OrderByDescending(article => article.Id).ToList(),
            };
            return this.View(new AllArticleQueryModel
            {
                CategoryId = articlModel.CategoryId,
                Categories = categories,
                Articles = articles,
                Sorting = articlModel.Sorting,
                CurrentPage = articlModel.CurrentPage,
                TotalArticles = totalArticles,
            });
        }

        public IActionResult Details()
        {
            var UrlType = Request.Path.Value;
            var lastindex = UrlType.LastIndexOf("/");
            int number = int.Parse(UrlType.Substring(lastindex + 1));

            var current =
                 this.data
                 .Articles
                 .Where(c => c.Id == number)
                 .FirstOrDefault();

            var currentArticle = new CurrentArticleViewModel()
            {
                Title = current.Title,
                ArticleContent = current.ArticleContent,
                ImageUrl = current.ImageUrl,
                Id = current.Id,
                AuthorId = current.AuthorId,

            };

            return this.View(currentArticle);

        }
    }
}