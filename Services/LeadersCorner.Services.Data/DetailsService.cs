namespace LeadersCorner.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using LeadersCorner.Data;
    using LeadersCorner.Web.ViewModels.Article;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;


    public class DetailsService : IDetailsService
    {
        private readonly LeadersCornerDbContext data;

        public DetailsService(LeadersCornerDbContext data)
        {
            this.data = data;

        }
        public async Task Details(
            string title,
            string articleContent,
            string imgUrl,
            int id,
            int authorId)
        {
            var detailArticle = new CurrentArticleViewModel()
            {
                Title = title,
                ArticleContent = articleContent,
                ImageUrl = imgUrl,
                Id = id,
                AuthorId = authorId,

            };

        }
    }
}
