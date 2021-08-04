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
        [Required]
        public int CategoryId { get; set; }
        
        public string CategoryName { get; set; }

        public IEnumerable<Category> Categories { get; set; }
            = new List<Category>();

        public string AuthorId { get;}

        public string ImageUrl { get; set; }
        public int Id { get; set; }

        // public IFormFile Image { get; set; }
    }
}
