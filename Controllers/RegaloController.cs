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
    public class RegaloController : Controller
    {
        private readonly matrimak_Context _context;

        public RegaloController(matrimak_Context context)
        {
            _context = context;
        }

        // GET: Regalo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Regalos.ToListAsync());
        }

        // GET: Regalo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regalo = await _context.Regalos
                .FirstOrDefaultAsync(m => m.IdRegalo == id);
            if (regalo == null)
            {
                return NotFound();
            }

            return View(regalo);
        }

        // GET: Regalo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Regalo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRegalo,NombreRegalo,CostoRegalo,DescripcionRegalo,Path")] Regalo regalo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regalo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regalo);
        }

        // GET: Regalo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regalo = await _context.Regalos.FindAsync(id);
            if (regalo == null)
            {
                return NotFound();
            }
            return View(regalo);
        }

        // POST: Regalo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRegalo,NombreRegalo,CostoRegalo,DescripcionRegalo,Path")] Regalo regalo)
        {
            if (id != regalo.IdRegalo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regalo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegaloExists(regalo.IdRegalo))
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
            return View(regalo);
        }

        // GET: Regalo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regalo = await _context.Regalos
                .FirstOrDefaultAsync(m => m.IdRegalo == id);
            if (regalo == null)
            {
                return NotFound();
            }

            return View(regalo);
        }

        // POST: Regalo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regalo = await _context.Regalos.FindAsync(id);
            _context.Regalos.Remove(regalo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegaloExists(int id)
        {
            return _context.Regalos.Any(e => e.IdRegalo == id);
        }
    }
}
