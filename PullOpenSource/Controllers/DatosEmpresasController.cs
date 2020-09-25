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
    public class DatosEmpresasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DatosEmpresasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DatosEmpresas
        public async Task<IActionResult> Index()
        {
            return View(await _context.DatosEmpresa.ToListAsync());
        }

        // GET: DatosEmpresas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosEmpresa = await _context.DatosEmpresa
                .FirstOrDefaultAsync(m => m.DatosEmpresaID == id);
            if (datosEmpresa == null)
            {
                return NotFound();
            }

            return View(datosEmpresa);
        }

        // GET: DatosEmpresas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DatosEmpresas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DatosEmpresaID,TipoRegistro,TipoArchivo,Identificacion,Periodo,CodigoMoneda")] DatosEmpresa datosEmpresa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(datosEmpresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(datosEmpresa);
        }

        // GET: DatosEmpresas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosEmpresa = await _context.DatosEmpresa.FindAsync(id);
            if (datosEmpresa == null)
            {
                return NotFound();
            }
            return View(datosEmpresa);
        }

        // POST: DatosEmpresas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DatosEmpresaID,TipoRegistro,TipoArchivo,Identificacion,Periodo,CodigoMoneda")] DatosEmpresa datosEmpresa)
        {
            if (id != datosEmpresa.DatosEmpresaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datosEmpresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatosEmpresaExists(datosEmpresa.DatosEmpresaID))
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
            return View(datosEmpresa);
        }

        // GET: DatosEmpresas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosEmpresa = await _context.DatosEmpresa
                .FirstOrDefaultAsync(m => m.DatosEmpresaID == id);
            if (datosEmpresa == null)
            {
                return NotFound();
            }

            return View(datosEmpresa);
        }

        // POST: DatosEmpresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var datosEmpresa = await _context.DatosEmpresa.FindAsync(id);
            _context.DatosEmpresa.Remove(datosEmpresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatosEmpresaExists(int id)
        {
            return _context.DatosEmpresa.Any(e => e.DatosEmpresaID == id);
        }
    }
}
