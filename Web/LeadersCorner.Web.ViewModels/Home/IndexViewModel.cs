using System.Collections.Generic;
using LeadersCorner.Data.Models;

namespace LeadersCorner.Web.ViewModels.Home
{
    public class IndexViewModel
    {
        public int ArticlesCout { get; set; }

        public int CourseCount { get; set; }

        public List<Data.Models.Article> Articles { get; set; } = new List<Data.Models.Article>();
        public List<Data.Models.Course> Courses { get; set; } = new List<Data.Models.Course>();

      //  public string Panel1 {get; set;}

    }
}
