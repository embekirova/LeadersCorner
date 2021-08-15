namespace LeadersCorner.Services.Data
{
    using LeadersCorner.Data;
    using LeadersCorner.Web.ViewModels.Article;
    using System.Linq;
    using System.Threading.Tasks;


    public class DetailsService : IDetailsService
    {
        private readonly LeadersCornerDbContext data;

        public DetailsService(LeadersCornerDbContext data)
        {
            this.data = data;
        }

        public CurrentArticleViewModel Details(int id)
        {
            var viewModel = this.data
                .Articles
                .Where(current => current.Id == id)
                .Select(current => new CurrentArticleViewModel
                {
                    Title = current.Title,
                    ArticleContent = current.ArticleContent,
                    ImageUrl = current.ImageUrl,
                    Id = current.Id,
                    AuthorId = current.AuthorId,
                    Comments = current.Comments,
                })
                .FirstOrDefault();
            return viewModel;

        }
    }
}
