namespace LeadersCorner.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using LeadersCorner.Data.Common;
    using LeadersCorner.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public string UserName { get; set; }

        public string UserFirstName { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [MinLength(DataConstants.Comment.ContentMinLength)]
        public string CommentContent { get; set; }

        public int? ArticleID { get; set; }

        public virtual Article Article { get; set; }

        public int? CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
