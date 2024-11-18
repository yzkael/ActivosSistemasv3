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
    public class MemoriasController : Controller
    {
        private readonly DbContext _context;

        public MemoriasController(DbContext context)
        {
            _context = context;
        }

        // GET: Memorias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Memoria.ToListAsync());
        }

        // GET: Memorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memoria = await _context.Memoria
                .FirstOrDefaultAsync(m => m.id == id);
            if (memoria == null)
            {
                return NotFound();
            }

            return View(memoria);
        }

        // GET: Memorias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Memorias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Marca,Capacidad,Tipo")] Memoria memoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(memoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(memoria);
        }

        // GET: Memorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memoria = await _context.Memoria.FindAsync(id);
            if (memoria == null)
            {
                return NotFound();
            }
            return View(memoria);
        }

        // POST: Memorias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Marca,Capacidad,Tipo")] Memoria memoria)
        {
            if (id != memoria.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(memoria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemoriaExists(memoria.id))
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
            return View(memoria);
        }

        // GET: Memorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memoria = await _context.Memoria
                .FirstOrDefaultAsync(m => m.id == id);
            if (memoria == null)
            {
                return NotFound();
            }

            return View(memoria);
        }

        // POST: Memorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var memoria = await _context.Memoria.FindAsync(id);
            if (memoria != null)
            {
                _context.Memoria.Remove(memoria);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemoriaExists(int id)
        {
            return _context.Memoria.Any(e => e.id == id);
        }
    }
}
