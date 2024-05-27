using CloudDevAssign.Models;
using CloudDevelopment.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloudDevAssign.Controllers
{
    public class ProductDisplayController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var product = ProductDisplayModel.SelectProducts();
            return View(product);
        }
    }
}
