using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Laboratorio_04.Models;

namespace Laboratorio_04.Controllers
{
    public class EgresoesController : Controller
    {
        private readonly DbEgresoContext _context;

        public EgresoesController(DbEgresoContext context)
        {
            _context = context;
        }

        // GET: Egresoes
        public async Task<IActionResult> Index()
        {
            var dbEgresoContext = _context.Egresos.Include(e => e.Usuario);
            return View(await dbEgresoContext.ToListAsync());
        }

        // GET: Egresoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var egreso = await _context.Egresos
                .Include(e => e.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (egreso == null)
            {
                return NotFound();
            }

            return View(egreso);
        }

        // GET: Egresoes/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id");
            return View();
        }

        // POST: Egresoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Valor,Descripcion,UsuarioId")] Egreso egreso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(egreso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", egreso.UsuarioId);
            return View(egreso);
        }

        // GET: Egresoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var egreso = await _context.Egresos.FindAsync(id);
            if (egreso == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", egreso.UsuarioId);
            return View(egreso);
        }

        // POST: Egresoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Valor,Descripcion,UsuarioId")] Egreso egreso)
        {
            if (id != egreso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(egreso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EgresoExists(egreso.Id))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", egreso.UsuarioId);
            return View(egreso);
        }

        // GET: Egresoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var egreso = await _context.Egresos
                .Include(e => e.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (egreso == null)
            {
                return NotFound();
            }

            return View(egreso);
        }

        // POST: Egresoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var egreso = await _context.Egresos.FindAsync(id);
            if (egreso != null)
            {
                _context.Egresos.Remove(egreso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EgresoExists(int id)
        {
            return _context.Egresos.Any(e => e.Id == id);
        }
    }
}
