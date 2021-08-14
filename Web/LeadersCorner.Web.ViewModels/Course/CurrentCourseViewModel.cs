namespace LeadersCorner.Web.ViewModels.Course
{
    using LeadersCorner.Data.Models;
    using System.Collections.Generic;

    public class CurrentCourseViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public int DurationInWeeks { get; set; }

        public int AuthorId { get; set; }

        public string CourseContent { get; set; }

        public ICollection<Comment>? Comments { get; set; }

        public Comment NewComment { get; set; }
    }
}
