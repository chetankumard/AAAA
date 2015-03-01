using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetExtendingIdentityRoles.Models;

namespace AspNetExtendingIdentityRoles.Controllers
{
    public class HomeController : BaseModel
    {

        public ActionResult Index()
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
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}