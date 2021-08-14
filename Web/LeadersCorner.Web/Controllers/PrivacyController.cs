namespace LeadersCorner.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class PrivacyController : BaseController
    {
        public IActionResult Privacy()
        {
            string filepath = "Files";
            byte[] pdfByte = System.IO.File.ReadAllBytes(filepath + "/Privacy.pdf");
            return File(pdfByte, "Files/pdf", "Privacy.pdf");
        }

    }
}
