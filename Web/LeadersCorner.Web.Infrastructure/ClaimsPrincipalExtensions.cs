using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace LeadersCorner.Web.Infrastructure
{
   public static class ClaimsPrincipalExtensions
    {
        public static string GetId(this ClaimsPrincipal user)
            => user.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
