namespace LeadersCorner.Services.Data
{
    using LeadersCorner.Web.ViewModels.Article;

    public interface IDetailsService
    {
        CurrentArticleViewModel Details(int id);
    }
}
