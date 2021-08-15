﻿namespace LeadersCorner.Web.Infrastructure
{
    using System.Security.Claims;

    using LeadersCorner.Common;

    public static class ClaimsPrincipalExtensions
    {
        public static string GetId(this ClaimsPrincipal user)
            => user.FindFirst(ClaimTypes.NameIdentifier).Value;

        public static bool IsAdmin(this ClaimsPrincipal user)
           => user.IsInRole(GlobalConstants.AdministratorRoleName);
    }
}
