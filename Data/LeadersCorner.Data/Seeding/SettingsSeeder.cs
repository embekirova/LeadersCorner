namespace LeadersCorner.Data.Seeding
{
    using LeadersCorner.Data.Models;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    internal class SettingsSeeder : ISeeder
    {
        public async Task SeedAsync(LeadersCornerDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Settings.Any())
            {
                return;
            }

            await dbContext.Settings.AddAsync(new Setting { Name = "Setting1", Value = "value1" });
        }
    }
}
