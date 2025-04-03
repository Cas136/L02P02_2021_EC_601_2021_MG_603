using Microsoft.AspNetCore.Mvc;

namespace L02P02_2021_EC_601_2021_MG_603.Controllers
{
    public class LibreriaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
