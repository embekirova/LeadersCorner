namespace LeadersCorner.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using LeadersCorner.Data;
    using LeadersCorner.Data.Models;
    using LeadersCorner.Web.ViewModels.Article;

    public class ArticleService : IArticleService
    {
        private readonly LeadersCornerDbContext data;

        public ArticleService(LeadersCornerDbContext data)
        {
            this.data = data;
        }

        public AllArticleQueryModel AllArticles(int currentPage, int categoryId, int sorting)
        {
            if (currentPage == 0)
            {
                currentPage = 1;
            }

            var categories = this.data
                .Categories
                .ToList();

            var articleQuery = this.data.Articles.AsQueryable();
            var articles = new List<Article>();
            articles = this.data.Articles.ToList();
            var totalArticles = articleQuery.Count();
            var totalArticlesOfAll = articleQuery.Count();

            if (sorting != 0 && sorting != 1 && sorting == 2)
            {
                sorting = 0;
            }

            var sortingType = (ArticleSorting)sorting;
            articles = sortingType switch
            {
                ArticleSorting.DateCreated => articles.OrderByDescending(c => c.Id).ToList(),
                ArticleSorting.ReverseDateCreated => articles.OrderBy(c => c.Id).ToList(),
                ArticleSorting.NullValue or _ => articles.OrderByDescending(c => c.Id).ToList(),
            };

            if (categoryId == 0)
            {
                totalArticles = articles.
                    OrderByDescending(article => article.Id)
                    .Count();

                articles = articles
               .Skip((currentPage - 1) * AllArticleQueryModel.ArticlesPerPage)
               .Take(AllArticleQueryModel.ArticlesPerPage)
               .OrderByDescending(article => article.Id)
               .ToList();

            }
            else
            {
                totalArticles = articles
                   .Where(c => c.CategoryId == categoryId)
                   .OrderByDescending(article => article.Id)
                   .Count();

                articles = articles
                    .Where(c => c.CategoryId == categoryId)
                    .Skip((currentPage - 1) * AllArticleQueryModel.ArticlesPerPage)
                    .Take(AllArticleQueryModel.ArticlesPerPage)
                    .OrderByDescending(article => article.Id)
                    .ToList();
            }

            var viewModel = new AllArticleQueryModel
            {
                CategoryId = categoryId,
                Categories = categories,
                Articles = articles,
                Sorting = sortingType,
                CurrentPage = currentPage,
                TotalArticles = totalArticles,
                TotalArticlesOfAll = totalArticlesOfAll,
            };

            return viewModel;
        }
    }
}
