namespace LeadersCorner.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using LeadersCorner.Data.Common;
    using LeadersCorner.Data.Common.Models;

    public class Author : BaseDeletableModel<int>
    {
        public Author()
        {
            this.Courses = new HashSet<Course>();
            this.Articles = new HashSet<Article>();
        }

        [Required]
        [MinLength(DataConstants.Author.NameMin)]
        [MaxLength(DataConstants.Author.NameMax)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(DataConstants.Author.NameMin)]
        [MaxLength(DataConstants.Author.NameMax)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Profession { get; set; }

        public bool ManagerOrLeaderPosition { get; set; }

        public string UserID { get; set; }

        public ICollection<Course> Courses { get; set; }

        public ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
