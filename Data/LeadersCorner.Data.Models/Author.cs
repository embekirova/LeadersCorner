namespace LeadersCorner.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using LeadersCorner.Data.Common.Models;

    public class Author : BaseDeletableModel<int>
    {
        public Author()
        {
            this.Courses = new HashSet<Course>();
            this.Articles = new HashSet<Article>();
        }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Profession { get; set; }

        public bool ManagerOrLeaderPosition { get; set; }

        public ICollection<Course> Courses { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
