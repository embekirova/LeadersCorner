namespace LeadersCorner.Web.Controllers
{
    using System.Linq;

    using LeadersCorner.Data.Common.Repositories;
    using LeadersCorner.Data.Models;
    using LeadersCorner.Web.ViewModels.Home;
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
        public IActionResult Error() => this.View();
    }
}
