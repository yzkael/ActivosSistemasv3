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
    public class DiscosDurosController : Controller
    {
        private readonly DbContext _context;

        public DiscosDurosController(DbContext context)
        {
            _context = context;
        }

        // GET: DiscosDuros
        public async Task<IActionResult> Index()
        {
            return View(await _context.DiscoDuro.ToListAsync());
        }

        // GET: DiscosDuros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discoDuro = await _context.DiscoDuro
                .FirstOrDefaultAsync(m => m.id == id);
            if (discoDuro == null)
            {
                return NotFound();
            }

            return View(discoDuro);
        }

        // GET: DiscosDuros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DiscosDuros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Marca,Capacidad,Tipo")] DiscoDuro discoDuro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(discoDuro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(discoDuro);
        }

        // GET: DiscosDuros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discoDuro = await _context.DiscoDuro.FindAsync(id);
            if (discoDuro == null)
            {
                return NotFound();
            }
            return View(discoDuro);
        }

        // POST: DiscosDuros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Marca,Capacidad,Tipo")] DiscoDuro discoDuro)
        {
            if (id != discoDuro.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(discoDuro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiscoDuroExists(discoDuro.id))
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
            return View(discoDuro);
        }

        // GET: DiscosDuros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discoDuro = await _context.DiscoDuro
                .FirstOrDefaultAsync(m => m.id == id);
            if (discoDuro == null)
            {
                return NotFound();
            }

            return View(discoDuro);
        }

        // POST: DiscosDuros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var discoDuro = await _context.DiscoDuro.FindAsync(id);
            if (discoDuro != null)
            {
                _context.DiscoDuro.Remove(discoDuro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiscoDuroExists(int id)
        {
            return _context.DiscoDuro.Any(e => e.id == id);
        }
    }
}
