namespace LeadersCorner.Data.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using LeadersCorner.Data.Common.Models;

    public class Article : BaseDeletableModel<int>
    {
        public Article(string authorId, string title)
        {
            this.Comments = new HashSet<Comment>();
            
            this.AuthorId = authorId;
            this.Title = title;
        }

        [Required]
        public string AuthorId { get; set; }

        public Author Author { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string ArticleContent { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        [Required]
        public IEnumerable<Article> Categories { get; set; } = new List<Article>();

        [DisplayName("Category")]
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
