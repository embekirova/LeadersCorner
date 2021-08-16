namespace LeadersCorner.Services.Data
{
    using System.Threading.Tasks;

    public interface ICommentService
    {
        Task Create(string commentcontent, int articleId, int courseId, int userId);

        Task DeleteCommentAsync(int commentId);
    }
}
