
namespace LeadersCorner.Web.ViewModels.Course
{
    using LeadersCorner.Data.Models;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class AllCourseQueryModel
    {
        public const int CoursesPerPage = 2;
        private int currentPage;
        private const int currentPageByDefault = 1;

        public string Category { get; set; }

        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; }

        public CourseSorting Sorting { get; set; }

        public int CurrentPage
        {
            get
            {
                if (this.currentPage < 1)
                {
                    return currentPageByDefault;
                }
                else
                {
                    return this.currentPage;
                }
            }
            set
            {
                if (value < 1)
                {
                    this.currentPage = 1;
                }
                this.currentPage = value;
            }
        }

        public int TotalCourses { get; set; }

        public int CategoryId { get; set; }

        [DisplayName("Category")]
        public string CategoryName { get; set; }

        [Required]
        public List<Category> Categories { get; set; }

        public List<Course> Courses { get; set; }

        public string Title { get; set; }

        public int DurationInWeeks { get; set; }
    }
}
