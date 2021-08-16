namespace LeadersCorner.Services.Data
{
    using System.Threading.Tasks;

    using LeadersCorner.Data;
    using LeadersCorner.Data.Models;

    public class CommentService : ICommentService
    {
        private readonly LeadersCornerDbContext data;

        public CommentService(LeadersCornerDbContext data)
        {
            this.data = data;
        }

        public async Task Create(string commentcontent, int articleId, int courseId, int userId)
        {
            var comment = new Comment();

            if (articleId == 0)
            {
                comment = new Comment
                {
                    CommentContent = commentcontent,
                    CourseId = courseId,
                    UserId = userId,
                };
            }
            else
            {
                comment = new Comment
                {
                    CommentContent = commentcontent,
                    ArticleID = articleId,
                    UserId = userId,
                };
            }

            await this.data.Comments.AddAsync(comment);
            await this.data.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(int commentId)
        {
            var comment = this.data
                .Comments
                .Find(commentId);

            this.data
                .Comments
                .Remove(comment);
            await this.data.SaveChangesAsync();
        }
    }
}
