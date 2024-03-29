﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GymManagementSystem.Models;

namespace GymManagementSystem.Controllers
{
    public class MembersController : Controller
    {
        private readonly GymDatabaseContext _context;

        public MembersController(GymDatabaseContext context)
        {
            _context = context;
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
             return View();
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.id = id;
            return View();
        }

        // GET: Members/Create
        public IActionResult Create(int? id)
        {
            ViewBag.userId = id;
            //ViewData["MembershipId"] = new SelectList(_context.MembershipTypes, "Id", "Id");
           // ViewData["TrainerId"] = new SelectList(_context.Trainers, "Id", "Id");
           // ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,UserId,TrainerId,MembershipId,JoinDate,ExpiryDate")] Member member)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(member);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["MembershipId"] = new SelectList(_context.MembershipTypes, "Id", "Id", member.MembershipId);
        //    ViewData["TrainerId"] = new SelectList(_context.Trainers, "Id", "Id", member.TrainerId);
        //    ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", member.UserId);
        //    return View(member);
        //}

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Members == null)
            {
                return NotFound();
            }

            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            ViewData["MembershipId"] = new SelectList(_context.MembershipTypes, "Id", "Id", member.MembershipId);
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "Id", "Id", member.TrainerId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", member.UserId);
            ViewBag.id = id;
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,TrainerId,MembershipId,JoinDate,ExpiryDate")] Member member)
        {
            if (id != member.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.Id))
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
            ViewData["MembershipId"] = new SelectList(_context.MembershipTypes, "Id", "Id", member.MembershipId);
            ViewData["TrainerId"] = new SelectList(_context.Trainers, "Id", "Id", member.TrainerId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", member.UserId);
            return View(member);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.id = id;
            return View();
        }

        // POST: Members/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.Members == null)
        //    {
        //        return Problem("Entity set 'GymDatabaseContext.Members'  is null.");
        //    }
        //    var member = await _context.Members.FindAsync(id);
        //    if (member != null)
        //    {
        //        _context.Members.Remove(member);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool MemberExists(int id)
        {
          return _context.Members.Any(e => e.Id == id);
        }
    }
}
