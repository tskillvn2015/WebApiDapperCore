using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApiDapperCore.Data.Constants;

namespace WebApiDapperCore.Filters
{
    public class ClaimRequirementFilter : IAuthorizationFilter
    {
        private readonly UserRole _userRole;
        public ClaimRequirementFilter(UserRole userRole)
        {
            _userRole = userRole;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var claimsIdentity = context.HttpContext.User.Identity as ClaimsIdentity;
            var permissionsClaim = context.HttpContext.User.Claims.SingleOrDefault(c => c.Type == SystemConstants.UserClaim.Roles);
            if (permissionsClaim != null)
            {
                var role = JsonConvert.DeserializeObject<List<string>>(permissionsClaim.Value);
                if (!role.Contains(_userRole+""))
                {
                    context.Result = new ForbidResult();
                }
            }
            else
            {
                context.Result = new ForbidResult();
            }
        }

    }
}
