﻿namespace LeadersCorner.Data.Models
{
    using LeadersCorner.Data.Common.Models;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Article : BaseDeletableModel<int>
    {
        public Article()
        {
        }

        public Article(int authorId, string title)
        {
            this.Comments = new HashSet<Comment>();
            this.AuthorId = authorId;
            this.Title = title;
        }

        public int Id { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public Author Author { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string ArticleContent { get; set; }

        [DisplayName("Photo")]
        public string ImageUrl { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        [Required]
        [DisplayName("Category")]
        public int CategoryId { get; set; }
    }
}
