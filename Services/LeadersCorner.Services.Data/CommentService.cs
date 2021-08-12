namespace LeadersCorner.Services.Data
{
    using LeadersCorner.Data;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using LeadersCorner.Data.Models;
    using Microsoft.AspNetCore.Identity;

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
    }
}
