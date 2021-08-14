using LeadersCorner.Data;
using System.Linq;

namespace LeadersCorner.Services.Data
{
    public class AuthorService : IAuthorService
    {
        private readonly LeadersCornerDbContext data;

        public AuthorService(LeadersCornerDbContext data)
            => this.data = data;
        public bool IsAuthor(string userId)
            => this.data
                .Authors
                .Any(d => d.UserID == userId);
    }
}
