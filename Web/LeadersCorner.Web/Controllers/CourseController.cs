namespace LeadersCorner.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LeadersCorner.Data;
    using LeadersCorner.Data.Models;
    using LeadersCorner.Services.Data;
    using LeadersCorner.Web.Infrastructure;
    using LeadersCorner.Web.ViewModels.Course;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class CourseController : BaseController
    {
        private readonly LeadersCornerDbContext data;
        private readonly ICommentService commentService;

        public CourseController(
            LeadersCornerDbContext data,
            ICommentService commentService)
        {
            this.data = data;
            this.commentService = commentService;
        }

        [Authorize]
        public IActionResult Create()
        {
            var categories = this.data
                .Categories.ToList();

            return this.View(new CreateCourseFormModel
            {
                Categories = categories,
            });
        }

        [HttpPost]
        [Authorize]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreateCourseFormModel course)
        {
            var userId = this.User.GetId();
            var userIsAnAuthor = this.data
                .Authors
                .Any(a => a.UserID == userId);

            var userIdentity = this.data
                .Authors
                .Where(c => c.UserID == userId)
                .FirstOrDefault();

            if (!userIsAnAuthor)
            {
                return this.BadRequest();
            }

            if (!this.data.Categories.Any(c => c.Id == c.Id))
            {
                this.ModelState.AddModelError(nameof(course.Id), "Category does not exist.");
            }

            if (!this.ModelState.IsValid)
            {
                var categories = this.data
                .Categories.ToList();

                return this.View(new CreateCourseFormModel
                {
                    Categories = categories,
                    Title = course.Title,
                    CourseContent = course.CourseContent,
                    ImageUrl = course.ImageUrl,
                    CategoryId = course.CategoryId,
                    Id = course.Id,
                    AuthorId = userIdentity.Id,
                    DurationInWeeks = course.DurationInWeeks,
                });
            }

            var courseData = new Course(userIdentity.Id, course.Title)
            {
                Title = course.Title,
                CourseContent = course.CourseContent,
                ImageUrl = course.ImageUrl,
                CategoryId = course.CategoryId,
                Id = course.Id,
                AuthorId = userIdentity.Id,
                DurationInWeeks = course.DurationInWeeks,
            };

            this.data.Courses.Add(courseData);
            this.data.SaveChanges();

            return this.View("CourseCreated");
        }

        public IActionResult All(int currentPage, int categoryId, int sorting)
        {
            if (currentPage == 0)
            {
                currentPage = 1;
            }

            var categories = this.data
                .Categories
                .ToList();

            var courseQuery = this.data.Courses.AsQueryable();
            var courses = new List<Course>();

            if (sorting != 0 && sorting != 1 && sorting == 2)
            {
                sorting = 0;
            }

            var sortingType = (CourseSorting)sorting;
            courses = sortingType switch
            {
                CourseSorting.DateCreated => courses.OrderByDescending(c => c.Id).ToList(),
                CourseSorting.ReverseDateCreated => courses.OrderBy(c => c.Id).ToList(),
                CourseSorting.NullValue => courses.OrderByDescending(c => c.Id).ToList(),
                _ => courses.OrderByDescending(article => article.Id).ToList(),
            };

            if (categoryId == 0)
            {
                courses = this.data
               .Courses
               .Skip((currentPage - 1) * AllCourseQueryModel.CoursesPerPage)
               .Take(AllCourseQueryModel.CoursesPerPage)
               .OrderByDescending(article => article.Id)
               .ToList();
            }
            else
            {
                courses = this.data
                    .Courses
                    .Where(c => c.CategoryId == categoryId)
                    .Skip((currentPage - 1) * AllCourseQueryModel.CoursesPerPage)
                    .Take(AllCourseQueryModel.CoursesPerPage)
                    .OrderByDescending(article => article.Id)
                    .ToList();
            }

            var totalcourses = courseQuery.Count();

            return this.View(new AllCourseQueryModel
            {
                CategoryId = categoryId,
                Categories = categories,
                Courses = courses,
                Sorting = sortingType,
                CurrentPage = currentPage,
                TotalCourses = totalcourses,
            });
        }

        public IActionResult Details(string id)
        {
            var comments = this.data
                .Comments
                .Where(c => c.CourseId == int.Parse(id))
                .ToList();

            var current =
                     this.data
                     .Courses
                     .Where(c => c.Id == int.Parse(id))
                     .FirstOrDefault();

            var currentCourse = new CurrentCourseViewModel()
            {
                Title = current.Title,
                CourseContent = current.CourseContent,
                ImageUrl = current.ImageUrl,
                Id = current.Id,
                AuthorId = current.AuthorId,
                Comments = comments,
                DurationInWeeks = current.DurationInWeeks,
            };

            return this.View(currentCourse);
        }

        [Authorize(Roles = "Administrator")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var commentArticle = this.data.Comments.Find(id).ArticleID;
            var commentCours = this.data.Comments.Find(id).CourseId;

            await this.commentService.DeleteCommentAsync(id);

            if (commentArticle != null)
            {
                return this.RedirectToAction("Details", "Article", new { id = commentArticle });
            }
            else
            {
                return this.RedirectToAction("Details", "Course", new { id = commentCours });
            }
        }
    }
}
