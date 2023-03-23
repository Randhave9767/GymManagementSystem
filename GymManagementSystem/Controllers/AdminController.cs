using GymManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace GymManagementSystem.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly GymDatabaseContext _context;

        public AdminController(GymDatabaseContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var userIds1 = _context.Trainers.Select(x => x.UserId).ToList();
            var userIds2 = _context.Members.Select(x => x.UserId).ToList();
            var userIds = userIds1.Union(userIds2);




            return View(await _context.Users.Where(x => !(userIds.Contains(x.Id))).ToListAsync());
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Username,Password,MobileNo")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'GymDatabaseContext.Users'  is null.");
            }
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }


        public async Task<IActionResult> GetTrainers()
        {
            //var gymDatabaseContext = _context.Trainers.Include(t => t.User);
            //return View(await gymDatabaseContext.ToListAsync());

            return View(await _context.Trainers.Include(t => t.User).ToListAsync());
        }

        public  async Task<IActionResult> AddTrainer()
        {
            

            var userIds1 = _context.Trainers.Select(x => x.UserId).ToList();
            var userIds2 = _context.Members.Select(x => x.UserId).ToList();
            var userIds = userIds1.Union(userIds2);




            return View(await _context.Users.Where( x => !(userIds.Contains(x.Id))).ToListAsync());

            //return View(await _context.Users.FromSql($"SELECT * FROM dbo.User").ToListAsync());

            //return View(await _context.Users.Where(x=>x.Id == 2).ToListAsync());
        }

        //public async Task<IActionResult> NewTrainer(int? id)
        //{
        //    ViewBag.Id = id;
        //    return View();
        //}

        public IActionResult NewTrainer(int? id)
        {
            
            return RedirectToAction("Create", "Trainers", new { UserId = id});
        }

        // POST: Trainers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> NewTrainer([Bind("Id,UserId,JoiningDate,Salary")] Trainer trainer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(trainer);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", trainer.UserId);
        //    return View(trainer);
        //}

        public async Task<IActionResult> GetTrainerMembersAsync(int? Id)
        {
            ViewBag.id = Id;
            var trainers = _context.Trainers.Include(x=>x.User) .ToList();
          //  Trainer trainer = trainers.FirstOrDefault(x=>x.Id == Id);
            ViewBag.TrainerName = trainers.FirstOrDefault(x => x.Id == Id).User.FullName.ToUpper();
            ViewBag.Contact = trainers.FirstOrDefault(x => x.Id == Id).User.MobileNo;
            ViewBag.Salary = trainers.FirstOrDefault(x => x.Id == Id).Salary;
            ViewBag.JoinDate = trainers.FirstOrDefault(x => x.Id == Id).JoiningDate;
            ViewBag.Count = _context.Members.Where(x => x.TrainerId == Id).ToList().Count;

            return View(await _context.Members.Include(t=>t.Membership).Include(u=>u.User).Where(x=>x.TrainerId == Id).ToListAsync());
        }


    }
}
