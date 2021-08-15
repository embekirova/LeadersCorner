namespace LeadersCorner.Web.Controllers
{
    using LeadersCorner.Data;
    using LeadersCorner.Data.Models;
    using LeadersCorner.Services.Data;
    using LeadersCorner.Web.ViewModels.Comment;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class CommentController : BaseController
    {
        private readonly LeadersCornerDbContext data;
        private readonly ICommentService commentService;
        private readonly UserManager<ApplicationUser> userManager;
        public CommentController(
            ICommentService commentService,
            UserManager<ApplicationUser> userManager)
        {
            this.commentService = commentService;
            this.userManager = userManager;
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateComment(CreateCommentFormModel comment)
        {
            await this.commentService.Create(comment.CommentContent, comment.ArticleID, comment.CourseID, comment.UserId);
            if (comment.ArticleID != 0)
            {
                return this.RedirectToAction("Details", "Article", new { id = comment.ArticleID });
            }
            else
            {
                return this.RedirectToAction("Details", "Course", new { id = comment.CourseID });
            }
        }
        
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> Delete(int commentId, int articleId, int courseId)
        {
            //var commentArticle = data.Comments.Find(commentId).ArticleID;
            //var commentCourse = data.Comments.Find(commentId).CourseId;

            await this.commentService.DeleteCommentAsync(commentId);
            if (articleId != 0)
            {
                return this.RedirectToAction("Details", "Article", new { id = articleId });
            }
            else
            {
                return this.RedirectToAction("Details", "Course", new { id = courseId });
            }
        }

    }
}
