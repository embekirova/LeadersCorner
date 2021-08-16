namespace LeadersCorner.Web.ViewModels.Article
{
    using System.ComponentModel.DataAnnotations;

    using Ganss.XSS;
    using LeadersCorner.Data.Common;
    using LeadersCorner.Services.Mapping;

    public class CreateCommentViewModel : IMapFrom<LeadersCorner.Data.Models.Comment>
    {
        public int Id { get; set; }

        [MinLength(DataConstants.Comment.ContentMinLength)]
        [Compare("CommnentContent", ErrorMessage = "Comment must have at least 2 symbols")]
        public string CommnentContent { get; set; }

        public string UserUserName { get; set; }

    }
}
