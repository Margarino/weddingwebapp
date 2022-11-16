using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using weddingWebapp.Models;

namespace weddingWebapp.Controllers
{
    public class OrdenregaloController : Controller
    {
        private readonly matrimak_Context _context;

        public OrdenregaloController(matrimak_Context context)
        {
            _context = context;
        }

        // GET: Ordenregalo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ordenregalos.ToListAsync());
        }

        // GET: Ordenregalo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenregalo = await _context.Ordenregalos
                .FirstOrDefaultAsync(m => m.IdOrdenRegalo == id);
            if (ordenregalo == null)
            {
                return NotFound();
            }

            return View(ordenregalo);
        }

        // GET: Ordenregalo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ordenregalo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOrdenRegalo,Correo,Nota,MontoRegalo")] Ordenregalo ordenregalo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordenregalo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ordenregalo);
        }

        // GET: Ordenregalo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenregalo = await _context.Ordenregalos.FindAsync(id);
            if (ordenregalo == null)
            {
                return NotFound();
            }
            return View(ordenregalo);
        }

        // POST: Ordenregalo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOrdenRegalo,Correo,Nota,MontoRegalo")] Ordenregalo ordenregalo)
        {
            if (id != ordenregalo.IdOrdenRegalo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordenregalo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenregaloExists(ordenregalo.IdOrdenRegalo))
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
            return View(ordenregalo);
        }

        // GET: Ordenregalo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordenregalo = await _context.Ordenregalos
                .FirstOrDefaultAsync(m => m.IdOrdenRegalo == id);
            if (ordenregalo == null)
            {
                return NotFound();
            }

            return View(ordenregalo);
        }

        // POST: Ordenregalo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordenregalo = await _context.Ordenregalos.FindAsync(id);
            _context.Ordenregalos.Remove(ordenregalo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenregaloExists(int id)
        {
            return _context.Ordenregalos.Any(e => e.IdOrdenRegalo == id);
        }
    }
}
