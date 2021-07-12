namespace LeadersCorner.Web.Areas.Administration.Controllers
{
    using LeadersCorner.Common;
    using LeadersCorner.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
