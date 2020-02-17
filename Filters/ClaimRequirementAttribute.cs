using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDapperCore.Filters
{
    public class ClaimRequirementAttribute : TypeFilterAttribute
    {
        public ClaimRequirementAttribute(UserRole userRole) : base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] { userRole };
        }
    }
}
