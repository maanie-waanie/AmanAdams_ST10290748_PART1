using CloudDevAssign.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloudDevAssign.Controllers
{
    public class userController1 : Controller
    {

        public userTable usrtbl = new userTable();

        [HttpPost]
        public ActionResult About(userTable Users)
        {
            var result = usrtbl.insert_User(Users);
            return RedirectToAction("Privacy", "Home");
        }

        [HttpPost]
        public ActionResult About()
        {
            return View(usrtbl);
        }

       
        public IActionResult Index()
        {
            return View();
        }
    }
}
