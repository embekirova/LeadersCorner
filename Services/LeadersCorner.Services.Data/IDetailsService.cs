using LeadersCorner.Web.ViewModels.Article;
using System.Threading.Tasks;

namespace LeadersCorner.Services.Data
{
    public interface IDetailsService
    {
        CurrentArticleViewModel Details(int id);

    }
}
