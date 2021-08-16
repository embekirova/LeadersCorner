namespace LeadersCorner.Web.Tests
{
    using System;

    using LeadersCorner.Data;
    using LeadersCorner.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class AuthorControllerTest
    {
        private readonly LeadersCornerDbContext data;

        [Fact]
        public void TestAddingAuthor()
        {
            var model = new Author
            {
                Id = 564,
                FirstName = "Kind",
                LastName = "Being",
            };

            var optionBuilder = new DbContextOptionsBuilder<LeadersCornerDbContext>()

            .UseInMemoryDatabase("myDbContextForTest");

            var dbContext = new LeadersCornerDbContext(optionBuilder.Options);

            dbContext.Authors.Add(model);
            dbContext.SaveChanges();

           // var controller = new CourseController(dbContext);

            Author result = dbContext.Authors.Find(564);

            Assert.NotNull(result);
            Assert.Equal("Kind", result.FirstName);
        }

        [Fact]
        public void ModelCouldnotBeNullOrEmpty()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                Author author = new Author();
                this.data.Authors.Add(author);
                this.data.SaveChanges();
            });
        }
    }
}
