namespace LeadersCorner.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using System.IO;

    using LeadersCorner.Data;
    using LeadersCorner.Data.Common.Repositories;
    using LeadersCorner.Data.Models;
    using LeadersCorner.Web.Infrastructure;
    using LeadersCorner.Web.ViewModels;
    using LeadersCorner.Web.ViewModels.Article;
    using LeadersCorner.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class PrivacyController : BaseController
    {
        public IActionResult Privacy ()
        {
            string filepath = "Files";
            byte[] pdfByte = System.IO.File.ReadAllBytes(filepath);
            return File(pdfByte, "application/pdf", "Privacy.pdf");
        }
     
    }
}
