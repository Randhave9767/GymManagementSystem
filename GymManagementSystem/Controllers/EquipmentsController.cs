using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GymManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace GymManagementSystem.Controllers
{
    [Authorize(Roles = "admin")]
    public class EquipmentsController : Controller
    {
        private readonly GymDatabaseContext _context;

        public EquipmentsController(GymDatabaseContext context)
        {
            _context = context;
        }

        // GET: Equipments
        public async Task<IActionResult> Index()
        {
              return View();
        }



        // GET: Equipments/Create
        public IActionResult Create()
        {
            return View();
        }


        
        public async Task<IActionResult> Edit(int? id)
        {
            

            ViewBag.id = id;
            return View();
        }


       
        public async Task<IActionResult> Delete(int? id)
        {

            ViewBag.id = id;
            return View();
        }


      


       
        private bool EquipmentExists(int id)
        {
          return _context.Equipment.Any(e => e.EquipmentId == id);
        }
    }
}
