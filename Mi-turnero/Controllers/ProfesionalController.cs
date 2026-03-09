using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mi_turnero.Data;
using Mi_turnero.Models;
using Microsoft.AspNetCore.Identity;

namespace Mi_turnero.Controllers
{
    public class ProfesionalController : Controller
    {
        private readonly MiTurneroDbContext _context;
        private readonly UserManager<Usuario> _userManager;
       
        public ProfesionalController(MiTurneroDbContext context, UserManager<Usuario>usuario)
        {
            _context = context;
            _userManager = usuario;
        }

        // GET: Profesionals
        public async Task<IActionResult> Index()
        {
            var profesionales = _context.Profesionales.Include(p => p.Especialidad);
            return View(await _context.Profesionales.ToListAsync());
        }

        // GET: Profesionals/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesional = await _context.Profesionales
                .Include(p => p.Especialidad)
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (profesional == null)
            {
                return NotFound();
            }

            return View(profesional);
        }

        // GET: Profesionals/Create
        public IActionResult Create()
        {
            ViewData["EspecialidadId"] = new SelectList(_context.Especialidades, "Id", "Nombre");
            return View();
        }

        // POST: Profesionals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,Matricula,EspecialidadId,Telefono,DuracionTurno,Activo")] Profesional profesional)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profesional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EspecialidadId"] = new SelectList(_context.Especialidades, "Id", "Nombre", profesional.EspecialidadId);
            return View(profesional);
        }

        // GET: Profesionals/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesional = await _context.Profesionales.FindAsync(id);
            if (profesional == null)
            {
                return NotFound();
            }
            ViewData["EspecialidadId"] = new SelectList(_context.Especialidades, "Id", "Nombre", profesional.EspecialidadId);
            return View(profesional);
        }

        // POST: Profesionals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UsuarioId,Matricula,EspecialidadId,Telefono,DuracionTurno,Activo")] Profesional profesional)
        {
            if (id != profesional.UsuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesionalExists(profesional.UsuarioId))
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
            ViewData["EspecialidadId"] = new SelectList(_context.Especialidades, "Id", "Nombre", profesional.EspecialidadId);
            return View(profesional);
        }

        // GET: Profesionals/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesional = await _context.Profesionales
                .Include(p => p.Especialidad)
                .FirstOrDefaultAsync(m => m.UsuarioId == id);
            if (profesional == null)
            {
                return NotFound();
            }

            return View(profesional);
        }

        // POST: Profesionals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var profesional = await _context.Profesionales.FindAsync(id);
            if (profesional != null)
            {
                _context.Profesionales.Remove(profesional);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesionalExists(string id)
        {
            return _context.Profesionales.Any(e => e.UsuarioId == id);
        }
    }
}
