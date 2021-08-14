namespace LeadersCorner.Data.Seeding
{
    using LeadersCorner.Data.Models;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    internal class CategorySeeder : ISeeder
    {
        public string Name { get; private set; }

        public async Task SeedAsync(LeadersCornerDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }


            await dbContext.AddAsync(new Category { CategoryName = "SelfImproving", CategoryLabel = "Self Improving" });
            await dbContext.AddAsync(new Category { CategoryName = "ProblemSolving", CategoryLabel = "Problem Solving" });
            await dbContext.AddAsync(new Category { CategoryName = "WorkAthmosphere", CategoryLabel = "Work Athmosphere" });
            await dbContext.AddAsync(new Category { CategoryName = "TimeManagement", CategoryLabel = "Time Management" });
            await dbContext.AddAsync(new Category { CategoryName = "PerformanceManagement", CategoryLabel = "Performance Management" });
            await dbContext.AddAsync(new Category { CategoryName = "Recruiting", CategoryLabel = "Recruiting" });
            await dbContext.AddAsync(new Category { CategoryName = "TeamMotivation", CategoryLabel = "Team Motivation" });

            await dbContext.SaveChangesAsync();
        }

    }
}
