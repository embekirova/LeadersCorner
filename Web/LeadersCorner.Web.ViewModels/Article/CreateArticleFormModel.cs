namespace LeadersCorner.Web.ViewModels.Article
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;

    using LeadersCorner.Data.Common;
    using LeadersCorner.Data.Models;

    public class CreateCommentFormModel
    {

        public CreateCommentFormModel()
        {

        }
        
        [Required]
        [MinLength(DataConstants.Article.TitleMinLength)]
        [MaxLength(DataConstants.Article.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(DataConstants.Article.ContentMinLength)]
        [DisplayName("Artile")]
        public string ArticleContent { get; set; }
        
        [Required]
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        public List<Category> Categories = new List<Category>(); 

        public int AuthorId { get;}

        public string ImageUrl { get; set; }
        public int Id { get; set; }

    }
}
