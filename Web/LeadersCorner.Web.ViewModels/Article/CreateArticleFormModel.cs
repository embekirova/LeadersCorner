namespace LeadersCorner.Web.ViewModels.Article
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using LeadersCorner.Data.Common;
    using LeadersCorner.Data.Models;

    public class CreateArticleFormModel
    {
        public CreateArticleFormModel()
        {
        }

        [Required(ErrorMessage = "The field is required")]
        [MinLength(DataConstants.Article.TitleMinLength, ErrorMessage = "Title of the article should be at least 10 symbols")]
        [MaxLength(DataConstants.Article.TitleMaxLength,ErrorMessage = "Title of the article should be not more than 50 symbols")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [DisplayName("Article")]
        [MinLength(DataConstants.Article.ContentMinLength, ErrorMessage = "The content must have at least {1} symbols")]
        public string ArticleContent { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [DisplayName("Category")]
        [Compare("CategoryId", ErrorMessage = "Please select category from the list")]
        public int CategoryId { get; set; }

        public List<Category> Categories = new List<Category>();

        public int AuthorId { get; set; }

        public string ImageUrl { get; set; }

        public int Id { get; set; }
    }
}
