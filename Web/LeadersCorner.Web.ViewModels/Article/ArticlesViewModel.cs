namespace LeadersCorner.Web.ViewModels.Article
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using LeadersCorner.Data.Common;
    using LeadersCorner.Data.Models;

    public class ArticlesViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string AuthorId { get; set; }

    }
}
