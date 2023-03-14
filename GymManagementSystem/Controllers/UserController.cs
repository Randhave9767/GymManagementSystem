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

        public IActionResult Index2()
        {
            int Id = -1;
            Id = (int)HttpContext.Session.GetInt32("Id");
            return RedirectToAction("Index", new { id = Id });
        }
        public IActionResult Index(int id)
        {
            int Id = -1;
                Id = (int)HttpContext.Session.GetInt32("Id");
            if(Id == id)
            {
                User u = _context.Users.FirstOrDefault(x => x.Id == id);
                ViewBag.id = id;

                return View(u);
            }

            return RedirectToAction("Login", "Account");
            
        }
    }
}
