namespace LeadersCorner.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using LeadersCorner.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        [Required]
        public string UseName { get; set; }

        [Required]
        public string CommentContent { get; set; }

        public int ArticleID { get; set; }

        public virtual Article Article { get; set; }
    }
}
