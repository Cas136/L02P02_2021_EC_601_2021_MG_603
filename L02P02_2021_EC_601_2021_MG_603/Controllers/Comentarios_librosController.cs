using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using L02P02_2021_EC_601_2021_MG_603.Models;

namespace L02P02_2021_EC_601_2021_MG_603.Controllers
{
    public class Comentarios_librosController : Controller
    {
        private readonly LibreriaDbContext _context;

        public Comentarios_librosController(LibreriaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.comentarios_libros.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentarios_libros = await _context.comentarios_libros
                .FirstOrDefaultAsync(m => m.id == id);
            if (comentarios_libros == null)
            {
                return NotFound();
            }

            return View(comentarios_libros);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,id_libro,comentarios,usuario,created_at")] comentarios_libros comentarios_libros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comentarios_libros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comentarios_libros);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentarios_libros = await _context.comentarios_libros.FindAsync(id);
            if (comentarios_libros == null)
            {
                return NotFound();
            }
            return View(comentarios_libros);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,id_libro,comentarios,usuario,created_at")] comentarios_libros comentarios_libros)
        {
            if (id != comentarios_libros.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comentarios_libros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!comentarios_librosExists(comentarios_libros.id))
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
            return View(comentarios_libros);
        }

        // GET: Comentarios_libros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentarios_libros = await _context.comentarios_libros
                .FirstOrDefaultAsync(m => m.id == id);
            if (comentarios_libros == null)
            {
                return NotFound();
            }

            return View(comentarios_libros);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comentarios_libros = await _context.comentarios_libros.FindAsync(id);
            if (comentarios_libros != null)
            {
                _context.comentarios_libros.Remove(comentarios_libros);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool comentarios_librosExists(int id)
        {
            return _context.comentarios_libros.Any(e => e.id == id);
        }
    }
}
