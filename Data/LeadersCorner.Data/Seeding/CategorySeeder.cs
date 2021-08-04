namespace LeadersCorner.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using LeadersCorner.Data.Models;

    internal class CategorySeeder : ISeeder
    {
        public async Task SeedAsync(LeadersCornerDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }
            

            await dbContext.AddAsync(new Category { CategoryName = "SelfImproving" });
            await dbContext.AddAsync(new Category { CategoryName = "ProblemSolving" });
            await dbContext.AddAsync(new Category { CategoryName = "WorkAthmosphere" });
            await dbContext.AddAsync(new Category { CategoryName = "TimeManagement" });
            await dbContext.AddAsync(new Category { CategoryName = "PerformanceManagement" });
            await dbContext.AddAsync(new Category { CategoryName = "Recruiting" });
            await dbContext.AddAsync(new Category { CategoryName = "TeamMotivation" });

            await dbContext.SaveChangesAsync();
        }

    }
}
