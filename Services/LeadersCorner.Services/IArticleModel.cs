using System;
using System.Collections.Generic;
using System.Text;

namespace LeadersCorner.Services
{
  public  interface IArticleModel
    {

        string Title { get; }

        string Category { get; }

        int Id { get; }
    }
}
