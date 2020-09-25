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
    public class DatosEmpleadosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DatosEmpleadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DatosEmpleados
        public async Task<IActionResult> Index()
        {
            return View(await _context.DatosEmpleado.ToListAsync());
        }

        // GET: DatosEmpleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosEmpleado = await _context.DatosEmpleado
                .FirstOrDefaultAsync(m => m.DatosEmpleadoId == id);
            if (datosEmpleado == null)
            {
                return NotFound();
            }

            return View(datosEmpleado);
        }

        // GET: DatosEmpleados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DatosEmpleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DatosEmpleadoId,EmpleadoId,Sueldo,NoCuenta")] DatosEmpleado datosEmpleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(datosEmpleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(datosEmpleado);
        }

        // GET: DatosEmpleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosEmpleado = await _context.DatosEmpleado.FindAsync(id);
            if (datosEmpleado == null)
            {
                return NotFound();
            }
            return View(datosEmpleado);
        }

        // POST: DatosEmpleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DatosEmpleadoId,EmpleadoId,Sueldo,NoCuenta")] DatosEmpleado datosEmpleado)
        {
            if (id != datosEmpleado.DatosEmpleadoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datosEmpleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatosEmpleadoExists(datosEmpleado.DatosEmpleadoId))
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
            return View(datosEmpleado);
        }

        // GET: DatosEmpleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosEmpleado = await _context.DatosEmpleado
                .FirstOrDefaultAsync(m => m.DatosEmpleadoId == id);
            if (datosEmpleado == null)
            {
                return NotFound();
            }

            return View(datosEmpleado);
        }

        // POST: DatosEmpleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var datosEmpleado = await _context.DatosEmpleado.FindAsync(id);
            _context.DatosEmpleado.Remove(datosEmpleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatosEmpleadoExists(int id)
        {
            return _context.DatosEmpleado.Any(e => e.DatosEmpleadoId == id);
        }
    }
}
