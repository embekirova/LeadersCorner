namespace LeadersCorner.Web.ViewModels.Article
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using LeadersCorner.Data.Common;
    using LeadersCorner.Data.Models;

    public class AllArticleQueryModel
    {
        public const int ArticlesPerPage = 6;

        public string Category { get; set; }

        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; }

      //  public CarSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalCars { get; set; }

        public IEnumerable<string> Brands { get; set; }

       // public IEnumerable<CarListingViewModel> Cars { get; set; }
    }
}
