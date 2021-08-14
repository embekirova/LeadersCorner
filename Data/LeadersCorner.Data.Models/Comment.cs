namespace LeadersCorner.Data.Models
{
    using LeadersCorner.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class Comment : BaseDeletableModel<int>
    {

        public string UserName { get; set; }


        [Required]
        public int UserId { get; set; }

        [Required]
        public string CommentContent { get; set; }

        public int? ArticleID { get; set; }

        public virtual Article Article { get; set; }

        public int? CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
