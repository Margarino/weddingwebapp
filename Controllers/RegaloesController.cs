using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using weddingWebapp.DataAccess.DataObjects;

namespace weddingWebapp.Controllers
{
    public class RegaloesController : Controller
    {
        private readonly matrimak_Context _context;

        public RegaloesController(matrimak_Context context)
        {
            _context = context;
        }

        // GET: Regaloes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Regalos.ToListAsync());
        }

        // GET: Regaloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regalo = await _context.Regalos
                .FirstOrDefaultAsync(m => m.Idregalo == id);
            if (regalo == null)
            {
                return NotFound();
            }

            return View(regalo);
        }

        // GET: Regaloes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Regaloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idregalo,NombreRegalo,NombreUsuario,Monto,Notaregalo")] Regalo regalo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regalo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regalo);
        }

        // GET: Regaloes/Edit/5
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

        // POST: Regaloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idregalo,NombreRegalo,NombreUsuario,Monto,Notaregalo")] Regalo regalo)
        {
            if (id != regalo.Idregalo)
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
                    if (!RegaloExists(regalo.Idregalo))
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

        // GET: Regaloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regalo = await _context.Regalos
                .FirstOrDefaultAsync(m => m.Idregalo == id);
            if (regalo == null)
            {
                return NotFound();
            }

            return View(regalo);
        }

        // POST: Regaloes/Delete/5
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
            return _context.Regalos.Any(e => e.Idregalo == id);
        }

        public IActionResult pushToTable()
        {
            matrimak_Context contex = new matrimak_Context();
            var memoryStream = new MemoryStream();
            var data = contex.Regalos.ToArray();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; //you greedy fucks
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Lista Regalos");
            workSheet.Cells[1, 1].LoadFromCollection(data, true);
            excel.SaveAs(memoryStream);
            memoryStream.Position = 0;
            string filename = "Lista Regalos.xlsx";
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            return File(memoryStream, contentType, filename);

        }



    }
}
