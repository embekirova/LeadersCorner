namespace LeadersCorner.Web.ViewModels.Course
{
    using LeadersCorner.Data.Common;
    using LeadersCorner.Data.Models;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class CreateCourseFormModel
    {
        public CreateCourseFormModel()
        {
        }

        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.Course.TitleMinLength)]
        [MaxLength(DataConstants.Course.TitleMaxLength)]
        [Compare("Title", ErrorMessage = "Title length have to be between 7 and 40 symmbols")]
        public string Title { get; set; }

        [Required]
        public int DurationInWeeks { get; set; }

        [Required]
        [MaxLength(DataConstants.Course.ContentMinLength)]
        [Compare("CourseContent", ErrorMessage = "Course description length have to be at least 70 symbols")]
        public string CourseContent { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        [DisplayName("Category")]
        [Compare("CategoryId", ErrorMessage = "Please select category from the list")]
        public int CategoryId { get; set; }

        public List<Category> Categories = new List<Category>();

        public string ImageUrl { get; set; }
    }
}
