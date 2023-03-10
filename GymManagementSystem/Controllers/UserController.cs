using GymManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace GymManagementSystem.Controllers
{
    [Authorize(Roles = "user")]
    public class UserController : Controller
    {
        private readonly GymDatabaseContext _context;

        public UserController(GymDatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            //User u = _context.Users.FirstOrDefault(x => x.Id == id );
            //return View(u);
            ViewBag.Id = id;
            return View();
        }
    }
}
