namespace LeadersCorner.Data.Models
{
    using LeadersCorner.Data.Common;
    using LeadersCorner.Data.Common.Models;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Course : BaseDeletableModel<int>
    {
        public Course()
        {
        }

        public Course(int authorId, string title)
        {
        }

        [Required]
        [MinLength(DataConstants.Course.TitleMinLength)]
        [MaxLength(DataConstants.Course.TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public int DurationInWeeks { get; set; }

        [Required]
        [MinLength(DataConstants.Course.ContentMinLength)]
        public string CourseContent { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

        [DisplayName("Photo")]
        public string ImageUrl { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        [Required]
        [DisplayName("Category")]
        public int CategoryId { get; set; }
    }
}
