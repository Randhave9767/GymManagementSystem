using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GymManagementSystem.Models;

namespace GymManagementSystem.Controllers
{
    public class UserfeedbacksController : Controller
    {
        private readonly GymDatabaseContext _context;

        public UserfeedbacksController(GymDatabaseContext context)
        {
            _context = context;
        }

        // GET: Userfeedbacks
        public async Task<IActionResult> Index()
        {
            var gymDatabaseContext = _context.Userfeedbacks.Include(u => u.User);
            return View(await gymDatabaseContext.ToListAsync());
        }

        // GET: Userfeedbacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            ViewBag.Id = id;

            return View();
        }

        // GET: Userfeedbacks/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Userfeedbacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Sub,Feedback,Seen")] Userfeedback userfeedback)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userfeedback);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userfeedback.UserId);
            return View(userfeedback);
        }

        // GET: Userfeedbacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Userfeedbacks == null)
            {
                return NotFound();
            }

            var userfeedback = await _context.Userfeedbacks.FindAsync(id);
            if (userfeedback == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userfeedback.UserId);
            return View(userfeedback);
        }

        // POST: Userfeedbacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Sub,Feedback,Seen")] Userfeedback userfeedback)
        {
            if (id != userfeedback.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userfeedback);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserfeedbackExists(userfeedback.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userfeedback.UserId);
            return View(userfeedback);
        }

        // GET: Userfeedbacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Userfeedbacks == null)
            {
                return NotFound();
            }

            var userfeedback = await _context.Userfeedbacks
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userfeedback == null)
            {
                return NotFound();
            }

            return View(userfeedback);
        }

        // POST: Userfeedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Userfeedbacks == null)
            {
                return Problem("Entity set 'GymDatabaseContext.Userfeedbacks'  is null.");
            }
            var userfeedback = await _context.Userfeedbacks.FindAsync(id);
            if (userfeedback != null)
            {
                _context.Userfeedbacks.Remove(userfeedback);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserfeedbackExists(int id)
        {
          return _context.Userfeedbacks.Any(e => e.Id == id);
        }
    }
}
