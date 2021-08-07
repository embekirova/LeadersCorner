namespace LeadersCorner.Web.ViewModels.Article
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using LeadersCorner.Data.Common;
    using LeadersCorner.Data.Models;
    using LeadersCorner.Services.Mapping;

    public class CurrentArticleViewModel : IMapFrom<Article>
    { 
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }
        public string ArticleContent { get; set; }
    }
}
