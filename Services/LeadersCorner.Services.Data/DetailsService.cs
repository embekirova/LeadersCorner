namespace LeadersCorner.Services.Data
{
    using LeadersCorner.Data;
    using LeadersCorner.Web.ViewModels.Article;
    using System.Threading.Tasks;


    public class DetailsService : IDetailsService
    {
        private readonly LeadersCornerDbContext data;

        public DetailsService(LeadersCornerDbContext data)
        {
            this.data = data;

        }
        public async Task Details(
            string title,
            string articleContent,
            string imgUrl,
            int id,
            int authorId)
        {
            var detailArticle = new CurrentArticleViewModel()
            {
                Title = title,
                ArticleContent = articleContent,
                ImageUrl = imgUrl,
                Id = id,
                AuthorId = authorId,

            };

        }
    }
}
