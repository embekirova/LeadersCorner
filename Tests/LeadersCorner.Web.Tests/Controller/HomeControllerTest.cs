namespace LeadersCorner.Web.Tests
{
    using LeadersCorner.Data;
    using LeadersCorner.Data.Common.Repositories;
    using LeadersCorner.Data.Models;
    using LeadersCorner.Web.Controllers;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    public class HomeControllerTest
    {
        private readonly LeadersCornerDbContext data;
        private readonly IDeletableEntityRepository<Article> articlesRepos;
        private readonly IDeletableEntityRepository<Course> coursesRepos;

        [Fact]
        public void StandartHomePageView()
        {
            MyController<HomeController>
                   .Instance()
                   .Calling(c => c.Index())
                   .ShouldHave()
                   .ValidModelState()
                   .AndAlso()
                   .ShouldReturn()
                   .View();
        }

        [Fact]
        public void HomeControllerShouldHaveNoAttributes()
    => MyController<HomeController>
        .Instance()
        .ShouldHave()
        .NoAttributes();

        [Fact]
        public void ErrorShouldReurnView()
        {
            var homeController = new HomeController(null, null);
            var result = homeController.Error();

            Assert.NotNull(result);
        }
    }
}
