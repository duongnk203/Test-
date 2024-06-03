using Microsoft.AspNetCore.Mvc;
using PetStoreProject.Models;

namespace PetStoreProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly PetStoreDBContext context;
        public HomeController(PetStoreDBContext dbContext) {
            context = dbContext;
        }
        public IActionResult Index()
        {
            return View(context.Brands.ToList()[0]);
        }
    }
}
