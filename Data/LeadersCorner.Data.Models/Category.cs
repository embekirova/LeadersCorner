namespace LeadersCorner.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Linq;

    using LeadersCorner.Data.Common.Models;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel;

    public class Category : BaseDeletableModel<int>
    {
       
        public int Id { get; set;}
        public string CategoryName { get; set;}

        public string CategoryLabel { get; set; }
        public IEnumerable<Article> ArticlesInCategory { get; set; } = new List<Article>();

        
    }
}
