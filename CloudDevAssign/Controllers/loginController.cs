using Microsoft.AspNetCore.Mvc;
using CloudDevAssign.Models;

namespace CloudDevAssign.Controllers
{
    public class loginController : Controller
    {
        public userTable usrtbl = new userTable();
        public IActionResult Index()
        {
            return View();
        }


        private readonly loginModel login;

        public loginController()
        {
            login = new loginModel();
        }

        [HttpPost]
        public ActionResult Privacy(string email, string name)
        {
            var loginModel = new loginModel();
            int userID = loginModel.SelectUser(email, name);
            if (userID != -1)
            {
                // Store userID in session
                HttpContext.Session.SetInt32("UserID", userID);

                // User found, proceed with login logic (e.g., set authentication cookie)
                // For demonstration, redirecting to a dummy page
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // User not found, handle accordingly (e.g., show error message)
                return View("LoginFailed");
            }
        }
    }

}

