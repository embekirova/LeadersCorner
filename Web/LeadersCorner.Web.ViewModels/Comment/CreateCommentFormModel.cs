namespace LeadersCorner.Web.ViewModels.Comment
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using LeadersCorner.Data.Common;

    public class CreateCommentFormModel
    {
        public int Id { get; set; }

        public int UserId { get; }

        public string UseName { get; set; }

        [Required]
        [MinLength(DataConstants.Article.ContentMinLength)]
        [DisplayName("Comment")]
        public string CommentContent { get; set; }

        public int ArticleID { get; set; }
    }
}
