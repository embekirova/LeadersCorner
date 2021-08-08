using LeadersCorner.Web.ViewModels.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadersCorner.Services.Data
{
   public interface IDetailsService
    {
        Task Details(
            string title,
            string articleContent,
            string imgUrl,
            int id,
            int authorId);

    }
}
