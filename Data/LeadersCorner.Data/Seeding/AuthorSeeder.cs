namespace LeadersCorner.Data.Seeding
{
    using LeadersCorner.Data.Models;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    internal class AuthorSeeder : ISeeder
    {
        public string Name { get; private set; }

        public async Task SeedAsync(LeadersCornerDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Authors.Any())
            {
                return;
            }

            await dbContext.AddAsync(new Author
            {
                FirstName = "Petya",
                LastName = "Petrova",
            });
            await dbContext.AddAsync(new Author
            {
                FirstName = "Stela",
                LastName = "Ivanova",
            });
            await dbContext.AddAsync(new Author
            {
                FirstName = "Georgi",
                LastName = "Georgiev",
            });
            await dbContext.AddAsync(new Author
            {
                FirstName = "Ivan",
                LastName = "Ivanov",
            });

            await dbContext.SaveChangesAsync();
        }

    }
}
