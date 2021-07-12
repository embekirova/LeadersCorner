namespace LeadersCorner.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using LeadersCorner.Data.Common.Models;

    public class CategoryArticle
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}
