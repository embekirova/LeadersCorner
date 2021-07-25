namespace LeadersCorner.Web.ViewModels.Article
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;

    using LeadersCorner.Data.Common;
    using LeadersCorner.Data.Models;

    public class CreateArticleFormModel
    {
        [Required]
        [MinLength(DataConstants.Article.TitleMinLength)]
        [MaxLength(DataConstants.Article.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(DataConstants.Article.ContentMinLength)]
        [DisplayName("Artile")]
        public string ArticleContent { get; set; }


        [DisplayName("Category")]
        public string CategoryId { get; set; }
        
        [Required]
        public IEnumerable<Article> Categories { get; set; } = new List<Article>();

        public string AuthorId { get;}

        public IFormFile Image { get; set; }
    }
}
