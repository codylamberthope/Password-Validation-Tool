using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PasswordValidation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Set1()
        {
            return View();
        }

        public ActionResult Set2()
        {
            return View();
        }


        public PartialViewResult ValidatePasswordOne(string Password, string ConfirmPassword)
        {
            var validationResults = Helpers.Validation.ValidatePassword(Password, ConfirmPassword, 10, true, true, false, false, false, false);

            return PartialView("_PasswordValidation", validationResults);
        }

        public PartialViewResult ValidatePasswordTwo(string Password, string ConfirmPassword)
        {
            var validationResults = Helpers.Validation.ValidatePassword(Password, ConfirmPassword, 8, true, true, true, true, true, true);

            return PartialView("_PasswordValidation_Set2", validationResults);
        }
    }
}