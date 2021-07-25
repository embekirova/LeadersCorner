namespace LeadersCorner.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(LeadersCornerDbContext dbContext, IServiceProvider serviceProvider);
    }
}
