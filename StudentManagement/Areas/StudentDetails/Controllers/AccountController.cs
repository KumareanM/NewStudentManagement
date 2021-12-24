using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.Controllers
{
    [Area("StudentDetails")]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
