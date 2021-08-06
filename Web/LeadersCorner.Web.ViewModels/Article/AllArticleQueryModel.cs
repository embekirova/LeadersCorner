namespace LeadersCorner.Web.ViewModels.Article
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using LeadersCorner.Data.Common;
    using LeadersCorner.Data.Models;

    public class AllArticleQueryModel
    {
        


        public const int ArticlesPerPage = 6;

        public string Category { get; set; }

        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; }

        public ArticleSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalArticles { get; set; }

        
        public string CategoryId { get; set; }

        [DisplayName("Category")]
        public string CategoryName { get; set; }

        [Required]
        public List<Category> Categories { get; set; }

        public IEnumerable<ArticlesViewModel> Articles { get; set; }
       
    }
}
