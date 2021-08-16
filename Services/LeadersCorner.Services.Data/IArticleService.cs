namespace LeadersCorner.Services.Data
{
    using LeadersCorner.Web.ViewModels.Article;

    public interface IArticleService
    {
        AllArticleQueryModel AllArticles(int currentPage, int categoryId, int sorting);
    }
}
