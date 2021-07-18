﻿namespace LeadersCorner.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using LeadersCorner.Data.Common.Models;

    public class Course : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string DurationInMonths { get; set; }

        [Required]
        public bool Certified { get; set; }

        public int Price { get; set; }

        [Required]
        public string CourseContent { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }
    }
}