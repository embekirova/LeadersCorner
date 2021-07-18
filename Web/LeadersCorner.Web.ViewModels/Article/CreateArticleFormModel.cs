namespace LeadersCorner.Web.ViewModels.Article
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

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
        public string ArticleContent { get; set; }

        [Required]
        public virtual ICollection<CategoryArticle> CategoriesOfArticle { get; set; }
    }
}
