using LeadersCorner.Data;
using LeadersCorner.Data.Models;
using LeadersCorner.Web.ViewModels.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace LeadersCorner.Services.Data
{
    public class ArticleService : IArticleService
    {
        private readonly LeadersCornerDbContext data;
        public ArticleService(LeadersCornerDbContext data)
        {
            this.data = data;
        }
        public AllArticleQueryModel AllArticles(int CurrentPage, int CategoryId, int Sorting)
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

            var viewModel = new AllArticleQueryModel
            {
                CategoryId = CategoryId,
                Categories = categories,
                Articles = articles,
                Sorting = sortingType,
                CurrentPage = CurrentPage,
                TotalArticles = totalArticles,
            };

            return viewModel;
        }

        
    }
}
