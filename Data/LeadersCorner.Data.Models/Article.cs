﻿namespace LeadersCorner.Data.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using LeadersCorner.Data.Common.Models;

    public class Article : BaseDeletableModel<int>
    {
        public Article(int authorId, string title)
        {
            this.Comments = new HashSet<Comment>();
            this.CategoriesOfArticle = new HashSet<CategoryArticle>();
            this.AuthorId = authorId;
            this.Title = title;
        }

        [Required]
        public int AuthorId { get; set; }

        public Author Author { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string ArticleContent { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        [Required]
        public virtual ICollection<CategoryArticle> CategoriesOfArticle { get; set; }
            = new List<CategoryArticle>();
    }
}