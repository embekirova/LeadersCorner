namespace LeadersCorner.Web.Tests
{
    using LeadersCorner.Data;
    using LeadersCorner.Services.Data;
    using Microsoft.EntityFrameworkCore;
    using System;
    using Xunit;

    public class AuthorServiceTest
    {
        [Fact]
        public void AuthorShouldBeTrueIfUserExists()
        {
            var options = new DbContextOptionsBuilder<LeadersCornerDbContext>()

                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

            string userId = "123";
            var dbContext = new LeadersCornerDbContext(options);

            dbContext.Authors.Add(new Data.Models.Author { UserID = "123", Id = 123 });
            dbContext.SaveChanges();

            var AuthorService = new LeadersCorner.Services.Data.AuthorService(dbContext);

            var result = AuthorService.IsAuthor(userId);

            Assert.True(result);
        }
    }
}