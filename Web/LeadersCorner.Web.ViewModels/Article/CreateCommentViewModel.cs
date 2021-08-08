namespace LeadersCorner.Web.ViewModels.Article
{
    using Ganss.XSS;
    using LeadersCorner.Services.Mapping;

    public class CreateCommentViewModel : IMapFrom<LeadersCorner.Data.Models.Comment>
    {
        public int Id { get; set; }

        public string CommnentContent { get;set;}

        public string UserUserName { get; set; }

        public string SanitazedContent => new HtmlSanitizer().Sanitize(this.CommnentContent);

    }
}