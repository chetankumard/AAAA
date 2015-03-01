using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetExtendingIdentityRoles.Models
{
    public class BaseModel : Controller
    {
        public BaseModel()
        {
            var rolename = "Ananomous";
            if (System.Web.HttpContext.Current.Session["User"] != null)
            {
                var identityUserRole = ((ApplicationUser)System.Web.HttpContext.Current.Session["User"]).Roles.FirstOrDefault();
                if (identityUserRole != null)
                {
                    rolename = identityUserRole.Role.Name;

                }
            }
            ViewBag.Role = rolename;
        }
    }

   
}