namespace LeadersCorner.Web.ViewModels.Article
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using LeadersCorner.Data.Common;
    using LeadersCorner.Data.Models;

    public enum ArticleSearch
    {
        
            DateCreated = 0,
            Year = 1,
            BrandAndModel = 2
        
    }
}
