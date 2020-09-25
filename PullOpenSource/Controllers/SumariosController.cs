using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PullOpenSource.Data;
using PullOpenSource.Models;

namespace PullOpenSource.Controllers
{
    public class SumariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SumariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sumarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sumario.ToListAsync());
        }

        // GET: Sumarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sumario = await _context.Sumario
                .FirstOrDefaultAsync(m => m.SumarioId == id);
            if (sumario == null)
            {
                return NotFound();
            }

            return View(sumario);
        }

        // GET: Sumarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sumarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SumarioId,CanEmpleados")] Sumario sumario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sumario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sumario);
        }

        // GET: Sumarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sumario = await _context.Sumario.FindAsync(id);
            if (sumario == null)
            {
                return NotFound();
            }
            return View(sumario);
        }

        // POST: Sumarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SumarioId,CanEmpleados")] Sumario sumario)
        {
            if (id != sumario.SumarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sumario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SumarioExists(sumario.SumarioId))
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
            return View(sumario);
        }

        // GET: Sumarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sumario = await _context.Sumario
                .FirstOrDefaultAsync(m => m.SumarioId == id);
            if (sumario == null)
            {
                return NotFound();
            }

            return View(sumario);
        }

        // POST: Sumarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sumario = await _context.Sumario.FindAsync(id);
            _context.Sumario.Remove(sumario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SumarioExists(int id)
        {
            return _context.Sumario.Any(e => e.SumarioId == id);
        }
    }
}
