using club.soundyard.web.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace club.soundyard.web.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
       
        [Authorize]
        public ActionResult Dashboard()
        {
            var userId = User.Identity.GetUserId();

            using (var context = new ApplicationDbContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    var userRoles = user.Roles.Select(r => r.RoleId);

                    var roleAgreements = new List<string>();

                    foreach (var roleId in userRoles)
                    {
                        var role = context.Roles.FirstOrDefault(r => r.Id == roleId);
                        if (role != null && role is ApplicationRole appRole)
                        {
                            roleAgreements.Add(appRole.Agreement);
                        }
                    }

                    ViewBag.RoleAgreements = roleAgreements;
                }
            }

            return View();
        }

        [Authorize]
        public ActionResult Administration()
        {
            return View();
        }

        [Authorize]
        public ActionResult Report()
        {
            return View();
        }
    }
}