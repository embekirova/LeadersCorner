using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeadersCorner.Services.Data
{
    public interface ICommentService
    {
        Task Create(string commentcontent, int articleId, int userId );
    }
}
