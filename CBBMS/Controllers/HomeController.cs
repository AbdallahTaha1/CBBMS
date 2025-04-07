using CBBMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace CBBMS.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
      
    }
}
