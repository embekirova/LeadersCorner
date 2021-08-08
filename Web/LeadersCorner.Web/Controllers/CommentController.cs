namespace LeadersCorner.Web.Controllers
{

    using System.Linq;
    using System.Threading.Tasks;
    using LeadersCorner.Data;
    using LeadersCorner.Data.Models;
    using LeadersCorner.Services.Data;
    using LeadersCorner.Web.Infrastructure;
    using LeadersCorner.Web.ViewModels.Comment;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> CreateComment(CreateCommentFormModel comment)
        {
            //var userId = this.userManager.GetUserId(this.User); 
            //var userIsAnAuthor = this.data
            //    .Authors
            //    .Any(a => a.UserID == userId);
            //var authorId = int.Parse(userId);

            await this.commentService.Create(comment.CommentContent, comment.ArticleID, comment.UserId);
            return this.RedirectToAction("Details", "Article", new { id = comment.ArticleID });
        }

    }
}
