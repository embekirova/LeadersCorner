namespace LeadersCorner.Web.ViewModels.Article
{
    using System.Collections.Generic;
    using Ganss.XSS;
    using LeadersCorner.Data.Models;
    using LeadersCorner.Services.Mapping;

    public class CurrentArticleViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public int AuthorId { get; set; }

        public string ArticleContent { get; set; }

        public ICollection<Comment>? Comments { get; set; }

        public Comment NewComment { get; set; }

        public string SanitazedContent => new HtmlSanitizer().Sanitize(this.ArticleContent);
    }
}
