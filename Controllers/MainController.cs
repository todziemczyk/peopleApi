using Microsoft.AspNetCore.Mvc;

namespace People.API.Controllers {
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }

}
