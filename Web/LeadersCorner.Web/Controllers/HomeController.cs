namespace LeadersCorner.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using LeadersCorner.Data;
    using LeadersCorner.Data.Common.Repositories;
    using LeadersCorner.Data.Models;
    using LeadersCorner.Web.ViewModels;
    using LeadersCorner.Web.ViewModels.Author;
    using LeadersCorner.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IDeletableEntityRepository<Article> articleRespository;
        private readonly IDeletableEntityRepository<Course> courseRepository;

        public HomeController(
            IDeletableEntityRepository<Article> articleRespository,
            IDeletableEntityRepository<Course> courseRepository)
        {
            this.articleRespository = articleRespository;
            this.courseRepository = courseRepository;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                ArticlesCout = this.articleRespository.All().Count(),
                CourseCount = this.courseRepository.All().Count(),
                
            };
            

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [HttpPost]

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
