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
    public class MembershipTypesController : Controller
    {
        private readonly GymDatabaseContext _context;

        public MembershipTypesController(GymDatabaseContext context)
        {
            _context = context;
        }

        // GET: MembershipTypes
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Index()
        {
              
              return View();
        }

        // GET: MembershipTypes/Details/5
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.id = id;

            return View();
        }

        // GET: MembershipTypes/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }



        // GET: MembershipTypes/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.id = id;
            return View();
        }

        // POST: MembershipTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,MembershipName,Fee,Description")] MembershipType membershipType)
        //{
        //    if (id != membershipType.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(membershipType);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!MembershipTypeExists(membershipType.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(membershipType);
        //}

        // GET: MembershipTypes/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            
            ViewBag.id = id;
            return View();


        }

        // POST: MembershipTypes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.MembershipTypes == null)
        //    {
        //        return Problem("Entity set 'GymDatabaseContext.MembershipTypes'  is null.");
        //    }
        //    var membershipType = await _context.MembershipTypes.FindAsync(id);
        //    if (membershipType != null)
        //    {
        //        _context.MembershipTypes.Remove(membershipType);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
        [Authorize(Roles = "admin")]
        private bool MembershipTypeExists(int id)
        {
          return _context.MembershipTypes.Any(e => e.Id == id);
        }
    }
}
