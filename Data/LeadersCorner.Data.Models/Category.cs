namespace LeadersCorner.Data.Models
{
    using LeadersCorner.Data.Common.Models;
    using System.Collections.Generic;

    public class Category : BaseDeletableModel<int>
    {

        public int Id { get; set; }
        public string CategoryName { get; set; }

        public string CategoryLabel { get; set; }
        public IEnumerable<Article> ArticlesInCategory { get; set; } = new List<Article>();


    }
}
