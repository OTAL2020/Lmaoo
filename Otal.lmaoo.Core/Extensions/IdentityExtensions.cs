using Otal.lmaoo.Core.Enums;
using System;
using System.Security.Claims;
using System.Security.Principal;

namespace Otal.lmaoo.Core.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetFullName(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            string forename = claimsIdentity?.FindFirst(ClaimTypes.GivenName).Value;
            string surname = claimsIdentity?.FindFirst(ClaimTypes.Surname).Value;

            if (string.IsNullOrEmpty(forename) || string.IsNullOrEmpty(surname))
                return String.Empty;

            return $"{forename} {surname}";
        }

        public static int GetRoleAsInteger(this IIdentity identity)
        {
            ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
            var role = claimsIdentity?.FindFirst(ClaimTypes.Role).Value;
            return (int)role.ParseEnum<UserRole>();
        }
    }
}