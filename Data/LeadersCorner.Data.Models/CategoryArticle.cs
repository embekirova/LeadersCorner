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
        public string Id { get; set; }

        [Required]
        public string CategoriID { get; set; }

        public Category Category { get; set; }

        [Required]
        public string ArticleId { get; set; }

        public Article Article { get; set; }
    }
}
