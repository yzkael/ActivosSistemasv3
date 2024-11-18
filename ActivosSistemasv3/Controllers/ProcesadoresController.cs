using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ActivosSistemasv3.Models;

namespace ActivosSistemasv3.Controllers
{
    public class ProcesadoresController : Controller
    {
        private readonly DbContext _context;

        public ProcesadoresController(DbContext context)
        {
            _context = context;
        }

        // GET: Procesadores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Procesador.ToListAsync());
        }

        // GET: Procesadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procesador = await _context.Procesador
                .FirstOrDefaultAsync(m => m.id == id);
            if (procesador == null)
            {
                return NotFound();
            }

            return View(procesador);
        }

        // GET: Procesadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Procesadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Marca,Modelo,Frecuencia")] Procesador procesador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procesador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(procesador);
        }

        // GET: Procesadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procesador = await _context.Procesador.FindAsync(id);
            if (procesador == null)
            {
                return NotFound();
            }
            return View(procesador);
        }

        // POST: Procesadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Marca,Modelo,Frecuencia")] Procesador procesador)
        {
            if (id != procesador.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procesador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcesadorExists(procesador.id))
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
            return View(procesador);
        }

        // GET: Procesadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var procesador = await _context.Procesador
                .FirstOrDefaultAsync(m => m.id == id);
            if (procesador == null)
            {
                return NotFound();
            }

            return View(procesador);
        }

        // POST: Procesadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var procesador = await _context.Procesador.FindAsync(id);
            if (procesador != null)
            {
                _context.Procesador.Remove(procesador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcesadorExists(int id)
        {
            return _context.Procesador.Any(e => e.id == id);
        }
    }
}
