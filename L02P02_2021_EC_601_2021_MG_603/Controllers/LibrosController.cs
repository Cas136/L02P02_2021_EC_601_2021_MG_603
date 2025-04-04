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
    public class LibrosController : Controller
    {
        private readonly LibreriaDbContext _context;

        public LibrosController(LibreriaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.libros.ToListAsync());
        }
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libros = await _context.libros
                .FirstOrDefaultAsync(m => m.id == id);
            if (libros == null)
            {
                return NotFound();
            }

            return View(libros);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nombre,descripcion,url_imagen,id_autor,id_categoria,precio,estado")] libros libros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(libros);
        }

      
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libros = await _context.libros.FindAsync(id);
            if (libros == null)
            {
                return NotFound();
            }
            return View(libros);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nombre,descripcion,url_imagen,id_autor,id_categoria,precio,estado")] libros libros)
        {
            if (id != libros.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!librosExists(libros.id))
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
            return View(libros);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libros = await _context.libros
                .FirstOrDefaultAsync(m => m.id == id);
            if (libros == null)
            {
                return NotFound();
            }

            return View(libros);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libros = await _context.libros.FindAsync(id);
            if (libros != null)
            {
                _context.libros.Remove(libros);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool librosExists(int id)
        {
            return _context.libros.Any(e => e.id == id);
        }
    }
}

