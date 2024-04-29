using CloudDevAssign.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloudDevAssign.Controllers
{
    public class userController1 : Controller
    {

        public userTable usrtbl = new userTable();
      

        [HttpPost]
        public ActionResult SignUp(userTable Users)
        {
            var result = usrtbl.insert_User(Users);
            return RedirectToAction("Privacy", "Home");
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View(usrtbl);
        }
        
       

    }
}
