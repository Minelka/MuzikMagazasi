using Microsoft.AspNetCore.Mvc;

namespace MuzikMagazasi.Controllers
{
    public class SarkilarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
