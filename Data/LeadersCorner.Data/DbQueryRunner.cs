namespace LeadersCorner.Data
{
    using LeadersCorner.Data.Common;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

    public class DbQueryRunner : IDbQueryRunner
    {
        public DbQueryRunner(LeadersCornerDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public LeadersCornerDbContext Context { get; set; }

        public Task RunQueryAsync(string query, params object[] parameters)
        {
            return this.Context.Database.ExecuteSqlRawAsync(query, parameters);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Context?.Dispose();
            }
        }
    }
}
