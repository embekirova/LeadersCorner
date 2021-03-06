namespace LeadersCorner.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public int ArticlesCout { get; set; }

        public int CourseCount { get; set; }

        public List<Data.Models.Article> Articles { get; set; } = new List<Data.Models.Article>();

        public List<Data.Models.Course> Courses { get; set; } = new List<Data.Models.Course>();
    }
}
