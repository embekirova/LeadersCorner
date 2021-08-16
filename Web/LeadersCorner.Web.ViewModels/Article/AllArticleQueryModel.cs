namespace LeadersCorner.Web.ViewModels.Article
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using LeadersCorner.Data.Models;

    public class AllArticleQueryModel
    {
        public const int ArticlesPerPage = 2;
        private int currentPage;
        private const int currentPageByDefault = 1;

        public string Category { get; set; }

        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; }

        public ArticleSorting Sorting { get; set; }

        public int CurrentPage
        {
            get
            {
                if (this.currentPage < 1)
                {
                    return currentPageByDefault;
                }
                else
                {
                    return this.currentPage;
                }
            }

            set
            {
                if (value < 1)
                {
                    this.currentPage = 1;
                }

                this.currentPage = value;
            }
        }

        public int TotalArticles { get; set; }

        public int CategoryId { get; set; }

        [DisplayName("Category")]
        public string CategoryName { get; set; }

        [Required]
        public List<Category> Categories { get; set; }

        public List<Article> Articles { get; set; }

        public string Title { get; set; }
    }
}
