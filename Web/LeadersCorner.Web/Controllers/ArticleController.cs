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

            return this.View(new CreateArticleFormModel
            {
                Categories = categories,
            });
        }

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


            if (!this.data.Categories.Any(c => c.Id == c.Id))
            {
                this.ModelState.AddModelError(nameof(article.Id), "Category does not exist.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(article);
            }

            var articleData = new Article(userId, article.Title)
            {
                Title = article.Title,
                ArticleContent = article.ArticleContent,
                ImageUrl = article.ImageUrl,
                CategoryId = article.CategoryId,
                Id = article.Id,
                AuthorId = userId,
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

            articles = sorting switch
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
                Sorting = sorting,
                CurrentPage = articlModel.CurrentPage,
            });
        }

        //[HttpPost]
        //[Authorize]
        //public IActionResult All(AllArticleQueryModel articlModel)
        //{

        //var categories = this.data
        //        .Categories.ToList();

        //    List<Article> articles = new List<Article>();

        //    if (articlModel.CategoryId == 0)
        //    {
        //        articles = this.data
        //       .Articles
        //       .Skip((articlModel.CurrentPage - 1) * AllArticleQueryModel.ArticlesPerPage)
        //       .Take(AllArticleQueryModel.ArticlesPerPage)
        //       .OrderByDescending(article => article.Id)
        //       .ToList();
        //    }
        //    else
        //    {
        //        articles = this.data
        //            .Articles
        //            .Where(c => c.CategoryId == articlModel.CategoryId)
        //            .Skip((articlModel.CurrentPage - 1) * AllArticleQueryModel.ArticlesPerPage)
        //            .Take(AllArticleQueryModel.ArticlesPerPage)
        //            .OrderByDescending(article => article.Id)
        //            .ToList();
        //    }

        //articles = sorting switch
        //    {
        //        ArticleSorting.DateCreated => articles.OrderByDescending(article=>article.Id).ToList(),
        //        ArticleSorting.ReverseDateCreated => articles.OrderBy(c => c.Id).ToList(),
        //        ArticleSorting.NullValue => articles.OrderBy(c => Guid.NewGuid()).ToList(),
        //        _=> articles.OrderByDescending(article => article.Id).ToList(),
        //    };
        //return this.View(new AllArticleQueryModel

        //    {
        //        CategoryId = articlModel.CategoryId,
        //        Categories = categories,
        //        Articles = articles,
        //        Sorting = sorting,
        //    });
        //}

    }
}
