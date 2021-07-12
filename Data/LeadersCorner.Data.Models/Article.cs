namespace LeadersCorner.Data.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using LeadersCorner.Data.Common.Models;

    public class Article : BaseDeletableModel<int>
    {
        public Article()
        {
            this.Comments = new HashSet<Comment>();
            this.CategoriesOfArticle = new HashSet<CategoryArticle>();
        }

        [Required]
        public int AuthorId { get; set; }

        public Author Author { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        [Required]
        public virtual ICollection<CategoryArticle> CategoriesOfArticle { get; set; }
    }
}
