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
        private int _id ;
        private readonly GymDatabaseContext _context;

        public TrainerHome(GymDatabaseContext context)
        {
            _context = context;
            
            
        }
        public IActionResult Index(int id)
        {
            try
            {
                _id = (int)HttpContext.Session.GetInt32("Id");

            }
            catch (Exception ex)
            {
                RedirectToAction("Login", "Account");
            }

            if (_id == id)
            {
               ViewBag.Id = _id;
                return View();
            }

            return RedirectToAction("Login", "Account");
            
        }

        public IActionResult MemberDetails(int id, int trainerId)
        {
            try
            {
                _id = (int)HttpContext.Session.GetInt32("Id");

            }
            catch (Exception ex)
            {
                
            }

            if (_id == trainerId)
            {
                ViewBag.id = trainerId;
                ViewBag.memberId = id;
                return View();
            }

            return RedirectToAction("Login", "Account");

            
        }

        public IActionResult GetMembers(int id)
        {
            try
            {
                _id = (int)HttpContext.Session.GetInt32("Id");

            }
            catch (Exception ex)
            {
                RedirectToAction("Login", "Account");
            }

            if (_id == id)
            {
                ViewBag.id = id;
                return View();
            }

            return RedirectToAction("Login", "Account");
            
        }

        public IActionResult Equipments(int id)
        {
            try
            {
                _id = (int)HttpContext.Session.GetInt32("Id");

            }
            catch (Exception ex)
            {
                RedirectToAction("Login", "Account");
            }

            if (_id == id)
            {
                ViewBag.Id = _id;
                return View();
            }

            return RedirectToAction("Login", "Account");

        }

        public IActionResult EquipmentRequests(int id) {

            try
            {
                _id = (int)HttpContext.Session.GetInt32("Id");

            }
            catch (Exception ex)
            {
                RedirectToAction("Login", "Account");
            }

            if (_id == id)
            {
                ViewBag.Id = _id;
                return View();
            }

            return RedirectToAction("Login", "Account");

        }

        public IActionResult NewRequest(int id)
        {
            try
            {
                _id = (int)HttpContext.Session.GetInt32("Id");

            }
            catch (Exception ex)
            {
                RedirectToAction("Login", "Account");
            }

            if (_id == id)
            {
                ViewBag.Id = _id;
                return View();
            }

            return RedirectToAction("Login", "Account");
        }

        public IActionResult Memberships(int id)
        {
            try
            {
                _id = (int)HttpContext.Session.GetInt32("Id");

            }
            catch (Exception ex)
            {
                RedirectToAction("Login", "Account");
            }

            if (_id == id)
            {
                ViewBag.Id = _id;
                return View();
            }

            return RedirectToAction("Login", "Account");

        }
    }
}
