namespace LeadersCorner.Web.ViewModels.Comment
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using Ganss.XSS;
    using LeadersCorner.Data.Common;
    using LeadersCorner.Services.Mapping;

    public class CreateCommentFormModel : IMapFrom<LeadersCorner.Data.Models.Comment>
    {
        public int Id { get; set; }

        public int UserId { get; }

        public string UseName { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [MinLength(DataConstants.Article.ContentMinLength, ErrorMessage = "Comment must have at least 2 symbols")]
        [DisplayName("Comment")]
        public string CommentContent { get; set; }

        public int ArticleID { get; set; }

        public int CourseID { get; set; }
    }
}
