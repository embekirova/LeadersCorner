namespace LeadersCorner.Web.ViewModels.Course
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using LeadersCorner.Data.Common;
    using LeadersCorner.Data.Models;

    public class CreateCourseFormModel
    {
        public CreateCourseFormModel()
        {
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int DurationInWeeks { get; set; }

        [Required]
        public string CourseContent { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        public List<Category> Categories = new List<Category>();

        public string ImageUrl { get; set; }
    }
}
