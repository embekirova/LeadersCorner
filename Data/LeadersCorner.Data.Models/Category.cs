namespace LeadersCorner.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using LeadersCorner.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.ArticlesInCategory = new HashSet<CategoryArticle>();
        }

        [Required]
        public string Name { get; set; }

        public ICollection<CategoryArticle> ArticlesInCategory { get; set; }
    }
}
