namespace LeadersCorner.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using LeadersCorner.Web.ViewModels.Article;

    public interface IArticleService
    {
        AllArticleQueryModel AllArticles(int CurrentPage, int CategoryId, int Sorting);
    }
}
