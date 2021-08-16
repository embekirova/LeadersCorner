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
        [MinLength(DataConstants.Course.TitleMinLength, ErrorMessage = "Title length have to be more than 7 symmbols")]
        [MaxLength(DataConstants.Course.TitleMaxLength, ErrorMessage = "Title length have to be less than 40 symmbols")]
        [Compare("Title", ErrorMessage = "Title length have to be between 7 and 40 symmbols")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Duration in weeks")]
        public int DurationInWeeks { get; set; }

        [Required]
        [DisplayName("Course Description")]
        [MaxLength(DataConstants.Course.ContentMinLength, ErrorMessage = "Course description length have to be at least 70 symbols")]
        public string CourseContent { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        public List<Category> Categories = new List<Category>();

        public string ImageUrl { get; set; }
    }
}
