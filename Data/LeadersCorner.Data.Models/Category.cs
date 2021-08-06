namespace LeadersCorner.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Linq;

    using LeadersCorner.Data.Common.Models;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel;

    public class Category : BaseDeletableModel<int>
    {
       
        public enum CategoryType
        {
            [Display(Name = "Self improvement")]
            SelfImproving = 0,
            [Display(Name = "Problem Solving")]
            ProblemSolving = 1,
            [Display(Name = "Positive working environment")]
            WorkAthmosphere = 2,
            [Display(Name = "Time management")]
            TimeManagement = 3,
            [Display(Name = "Performance management")]
            PerformanceManagement = 4,
            [Display(Name = "Recruitment")]
            Recruiting = 4,
            [Display(Name = "Team motivation")]
            TeamMotivation = 5,

        }
        public int Id { get; set;}
        public string CategoryName { get; set;}

        public string CategoryLabel { get; set; }
        public IEnumerable<Article> ArticlesInCategory { get; set; } = new List<Article>();
    }
}
