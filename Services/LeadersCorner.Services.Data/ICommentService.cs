using System.Threading.Tasks;

namespace LeadersCorner.Services.Data
{
    public interface ICommentService
    {
        Task Create(string commentcontent, int articleId, int courseId, int userId);
    }
}
