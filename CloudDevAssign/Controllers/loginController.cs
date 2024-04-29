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
        public ActionResult Privacy(string email, string name, string password)
        {
            var loginModel = new loginModel();
            int userID = loginModel.SelectUser(email, name, password);
            if (userID != -1)
            {
              
                return RedirectToAction("Index", "Home", new { userID = userID });
            }
            else
            {
                return View("LoginFailed");
            }
        }

        [HttpGet]
        public ActionResult Privacy()
        {
            return View(usrtbl);
        }
    }
}
