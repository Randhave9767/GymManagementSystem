using GymManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace GymManagementSystem.Controllers
{
    [Authorize(Roles = "trainer")]
    public class TrainerHome : Controller
    {
        private readonly GymDatabaseContext _context;

        public TrainerHome(GymDatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            Trainer t = _context.Trainers.Include(t=>t.User).Include(t=>t.Members).FirstOrDefault(x => x.Id == id);
            return View(t);
        }
    }
}
