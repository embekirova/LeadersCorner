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
    using LeadersCorner.Web.ViewModels.Course;
    using LeadersCorner.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http.Extensions;

    public class CourseController : BaseController
    {
        private readonly LeadersCornerDbContext data;
       // private readonly ArticleSorting sortingType;

        public CourseController(
            LeadersCornerDbContext data)
        => this.data = data;

        [Authorize]
        public IActionResult Create()
        {
            var categories = this.data
                .Categories.ToList();

            return this.View(new CreateCourseFormModel
            {
                Categories = categories,
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateCourseFormModel course)
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
                this.ModelState.AddModelError(nameof(course.Id), "Category does not exist.");
            }

            if (!this.ModelState.IsValid)
            {
                var categories = this.data
                .Categories.ToList();

                return this.View(new CreateCourseFormModel
                {
                    Categories = categories,
                    Title = course.Title,
                    CourseContent = course.CourseContent,
                    ImageUrl = course.ImageUrl,
                    CategoryId = course.CategoryId,
                    Id = course.Id,
                    AuthorId = userIdentity.Id,
                    DurationInWeeks = course.DurationInWeeks,
                });
            }

            var courseData = new Course(userIdentity.Id, course.Title)
            {
                Title = course.Title,
                CourseContent = course.CourseContent,
                ImageUrl = course.ImageUrl,
                CategoryId = course.CategoryId,
                Id = course.Id,
                AuthorId = userIdentity.Id,
                DurationInWeeks = course.DurationInWeeks,
            };

            this.data.Courses.Add(courseData);
            this.data.SaveChanges();

            return this.View("CourseCreated");
        }

        //public IActionResult All(int CurrentPage, int CategoryId, int Sorting)
        //{
        //    if (CurrentPage == 0)
        //    {
        //        CurrentPage = 1;
        //    }
        //    var categories = this.data
        //        .Categories
        //        .ToList();

        //    var articleQuery = this.data.Articles.AsQueryable();
        //    var articles = new List<Article>();

        //    if (Sorting != 0 && Sorting != 1 && Sorting == 2)
        //    {
        //        Sorting = 0;
        //    }

        //    var sortingType = (ArticleSorting)Sorting;
        //    articles = sortingType switch
        //    {
        //        ArticleSorting.DateCreated => articles.OrderByDescending(c => c.Id).ToList(),
        //        ArticleSorting.ReverseDateCreated => articles.OrderBy(c => c.Id).ToList(),
        //        ArticleSorting.NullValue => articles.OrderByDescending(c => c.Id).ToList(),
        //        _ => articles.OrderByDescending(article => article.Id).ToList(),
        //    };

        //    if (CategoryId == 0)
        //    {
        //        articles = this.data
        //       .Articles
        //       .Skip((CurrentPage - 1) * AllArticleQueryModel.ArticlesPerPage)
        //       .Take(AllArticleQueryModel.ArticlesPerPage)
        //       .OrderByDescending(article => article.Id)
        //       .ToList();
        //    }
        //    else
        //    {
        //        articles = this.data
        //            .Articles
        //            .Where(c => c.CategoryId == CategoryId)
        //            .Skip((CurrentPage - 1) * AllArticleQueryModel.ArticlesPerPage)
        //            .Take(AllArticleQueryModel.ArticlesPerPage)
        //            .OrderByDescending(article => article.Id)
        //            .ToList();
        //    }

        //    var totalArticles = articleQuery.Count();

        //    return this.View(new AllArticleQueryModel
        //    {
        //        CategoryId = CategoryId,
        //        Categories = categories,
        //        Articles = articles,
        //        Sorting = sortingType,
        //        CurrentPage = CurrentPage,
        //        TotalArticles = totalArticles,
        //    });
        //}

        //public IActionResult Details(string id)
        //{
        //    var comments = this.data
        //        .Comments
        //        .Where(c => c.ArticleID == int.Parse(id))
        //        .ToList();

        //    var current =
        //         this.data
        //         .Articles
        //         .Where(c => c.Id == int.Parse(id))
        //         .FirstOrDefault();

        //    var currentArticle = new CurrentArticleViewModel()
        //    {
        //        Title = current.Title,
        //        ArticleContent = current.ArticleContent,
        //        ImageUrl = current.ImageUrl,
        //        Id = current.Id,
        //        AuthorId = current.AuthorId,
        //        Comments = comments,
        //    };

        //    return this.View(currentArticle);
        //}
    }
}