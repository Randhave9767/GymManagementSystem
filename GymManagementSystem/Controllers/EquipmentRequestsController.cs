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
    public class EquipmentRequestsController : Controller
    {
        private readonly GymDatabaseContext _context;

        public EquipmentRequestsController(GymDatabaseContext context)
        {
            _context = context;
        }

        // GET: EquipmentRequests

       
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> GetApprovedRequests()
        {
            return View();
        }

        public async Task<IActionResult> GetClosedRequests()
        {
            return View();
        }

        // GET: EquipmentRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.Id = id;
            return View();
        }

        // GET: EquipmentRequests/Create
        public IActionResult Create()
        {
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "Id", "Id");
            return View();
        }

        // POST: EquipmentRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EquipmentName,Quantity,RequestStatus,TrainerId,Reason")] EquipmentRequest equipmentRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipmentRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "Id", "Id", equipmentRequest.TrainerId);
            return View(equipmentRequest);
        }

        // GET: EquipmentRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EquipmentRequests == null)
            {
                return NotFound();
            }

            var equipmentRequest = await _context.EquipmentRequests.FindAsync(id);
            if (equipmentRequest == null)
            {
                return NotFound();
            }
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "Id", "Id", equipmentRequest.TrainerId);
            return View(equipmentRequest);
        }

        // POST: EquipmentRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EquipmentName,Quantity,RequestStatus,TrainerId,Reason")] EquipmentRequest equipmentRequest)
        {
            if (id != equipmentRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipmentRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipmentRequestExists(equipmentRequest.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "Id", "Id", equipmentRequest.TrainerId);
            return View(equipmentRequest);
        }

        // GET: EquipmentRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EquipmentRequests == null)
            {
                return NotFound();
            }

            var equipmentRequest = await _context.EquipmentRequests
                .Include(e => e.Trainer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipmentRequest == null)
            {
                return NotFound();
            }

            return View(equipmentRequest);
        }

        // POST: EquipmentRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EquipmentRequests == null)
            {
                return Problem("Entity set 'GymDatabaseContext.EquipmentRequests'  is null.");
            }
            var equipmentRequest = await _context.EquipmentRequests.FindAsync(id);
            if (equipmentRequest != null)
            {
                _context.EquipmentRequests.Remove(equipmentRequest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipmentRequestExists(int id)
        {
          return (_context.EquipmentRequests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
