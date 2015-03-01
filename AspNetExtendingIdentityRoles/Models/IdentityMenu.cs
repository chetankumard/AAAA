using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AspNetExtendingIdentityRoles.Models
{
    public class IdentityMenu
    {
        RoleManager<ApplicationRole> _roleManager = new RoleManager<ApplicationRole>(
         new RoleStore<ApplicationRole>(new ApplicationDbContext()));
    }
}