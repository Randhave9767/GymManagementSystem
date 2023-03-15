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
            try
            {
                Id = (int)HttpContext.Session.GetInt32("Id");
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Index", new { id = Id });
        }
        public IActionResult Index(int id)
        {
            int Id = -1;
            try
            {
                Id = (int)HttpContext.Session.GetInt32("Id");
            }catch (Exception ex)
            {

            }
                
            if(Id == id)
            {
               // User u = _context.Users.FirstOrDefault(x => x.Id == id);
                ViewBag.id = id;

                return View();
            }

            return RedirectToAction("Login", "Account");
            
        }

        public IActionResult feedbackIndex()
        {
            int id = -1;
            try
            {
                id = (int)HttpContext.Session.GetInt32("Id");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "Account");
            }

           
                
                ViewBag.Id = id;

                return View();
            

            
        }

        public IActionResult CreateFeedback()
        {
            int id = -1;
            try
            {
                id = (int)HttpContext.Session.GetInt32("Id");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Login", "Account");
            }

            
                ViewBag.Id = id;

                return View();
            

            
        }
    }
}
