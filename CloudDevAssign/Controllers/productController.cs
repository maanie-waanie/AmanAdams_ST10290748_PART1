using CloudDevAssign.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;


namespace CloudDevAssign.Controllers
{
    public class productController : Controller
    {
        public productTable prdttbl = new productTable();

        [HttpPost]
        public ActionResult Work(productTable Products)
        {
            var result2 = prdttbl.insert_product(Products);
            return RedirectToAction("Work", "Home");
        }

        [HttpGet]
        public ActionResult Work()
        {
            return View(prdttbl);
        }

         
    }
}
