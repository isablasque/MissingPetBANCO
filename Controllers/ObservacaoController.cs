using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MissingPet.Models;

namespace MissingPet.Controllers
{
    public class ObservacaoController : Controller
    {
        private readonly Contexto _context;

        public ObservacaoController(Contexto context)
        {
            _context = context;
        }

        // GET: Observacao
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Observacao.Include(o => o.Animal).Include(o => o.Usuario);
            return View(await contexto.ToListAsync());
        }

        // GET: Observacao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Observacao == null)
            {
                return NotFound();
            }

            var observacao = await _context.Observacao
                .Include(o => o.Animal)
                .Include(o => o.Usuario)
                .FirstOrDefaultAsync(m => m.ObservacaoId == id);
            if (observacao == null)
            {
                return NotFound();
            }

            return View(observacao);
        }

        // GET: Observacao/Create
        public IActionResult Create()
        {
            ViewData["AnimalId"] = new SelectList(_context.Animal, "AnimalId", "AnimalNome");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioNome");
            return View();
        }

        // POST: Observacao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ObservacaoId,ObservacaoDescricao,ObservacaoLocal,ObservacaoData,AnimalId,UsuarioId")] Observacao observacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(observacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimalId"] = new SelectList(_context.Animal, "AnimalId", "AnimalNome", observacao.AnimalId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioNome", observacao.UsuarioId);
            return View(observacao);
        }

        // GET: Observacao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Observacao == null)
            {
                return NotFound();
            }

            var observacao = await _context.Observacao.FindAsync(id);
            if (observacao == null)
            {
                return NotFound();
            }
            ViewData["AnimalId"] = new SelectList(_context.Animal, "AnimalId", "AnimalNome", observacao.AnimalId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioNome", observacao.UsuarioId);
            return View(observacao);
        }

        // POST: Observacao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ObservacaoId,ObservacaoDescricao,ObservacaoLocal,ObservacaoData,AnimalId,UsuarioId")] Observacao observacao)
        {
            if (id != observacao.ObservacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(observacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObservacaoExists(observacao.ObservacaoId))
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
            ViewData["AnimalId"] = new SelectList(_context.Animal, "AnimalId", "AnimalNome", observacao.AnimalId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "UsuarioNome", observacao.UsuarioId);
            return View(observacao);
        }

        // GET: Observacao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Observacao == null)
            {
                return NotFound();
            }

            var observacao = await _context.Observacao
                .Include(o => o.Animal)
                .Include(o => o.Usuario)
                .FirstOrDefaultAsync(m => m.ObservacaoId == id);
            if (observacao == null)
            {
                return NotFound();
            }

            return View(observacao);
        }

        // POST: Observacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Observacao == null)
            {
                return Problem("Entity set 'Contexto.Observacao'  is null.");
            }
            var observacao = await _context.Observacao.FindAsync(id);
            if (observacao != null)
            {
                _context.Observacao.Remove(observacao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObservacaoExists(int id)
        {
          return (_context.Observacao?.Any(e => e.ObservacaoId == id)).GetValueOrDefault();
        }
    }
}
