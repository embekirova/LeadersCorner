namespace LeadersCorner.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using LeadersCorner.Data;
    using LeadersCorner.Data.Models;
    using LeadersCorner.Web.Infrastructure;
    using LeadersCorner.Web.ViewModels.Course;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class CourseController : BaseController
    {
        private readonly LeadersCornerDbContext data;
       // private readonly ArticleSorting sortingType;

        public CourseController(
            LeadersCornerDbContext data)
        => this.data = data;

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

        public IActionResult All(int CurrentPage, int CategoryId, int Sorting)
        {
            if (CurrentPage == 0)
            {
                CurrentPage = 1;
            }
            var categories = this.data
                .Categories
                .ToList();

            var courseQuery = this.data.Courses.AsQueryable();
            var courses = new List<Course>();

            if (Sorting != 0 && Sorting != 1 && Sorting == 2)
            {
                Sorting = 0;
            }

            var sortingType = (CourseSorting)Sorting;
            courses = sortingType switch
            {
                CourseSorting.DateCreated => courses.OrderByDescending(c => c.Id).ToList(),
                CourseSorting.ReverseDateCreated => courses.OrderBy(c => c.Id).ToList(),
                CourseSorting.NullValue => courses.OrderByDescending(c => c.Id).ToList(),
                _ => courses.OrderByDescending(article => article.Id).ToList(),
            };

            if (CategoryId == 0)
            {
                courses = this.data
               .Courses
               .Skip((CurrentPage - 1) * AllCourseQueryModel.CoursesPerPage)
               .Take(AllCourseQueryModel.CoursesPerPage)
               .OrderByDescending(article => article.Id)
               .ToList();
            }
            else
            {
                courses = this.data
                    .Courses
                    .Where(c => c.CategoryId == CategoryId)
                    .Skip((CurrentPage - 1) * AllCourseQueryModel.CoursesPerPage)
                    .Take(AllCourseQueryModel.CoursesPerPage)
                    .OrderByDescending(article => article.Id)
                    .ToList();
            }

            var totalcourses = courseQuery.Count();

            return this.View(new AllCourseQueryModel
            {
                CategoryId = CategoryId,
                Categories = categories,
                Courses = courses,
                Sorting = sortingType,
                CurrentPage = CurrentPage,
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
    }
}