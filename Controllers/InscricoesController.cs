using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FormularioInscricao.Data;
using FormularioInscricao.Models;

namespace FormularioInscricao.Controllers
{
    public class InscricoesController : Controller
    {
        private readonly AppDbContext _context;

        public InscricoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Inscricaos
        public async Task<IActionResult> Index()
        {
            if (_context == null)
                return Content("Contexto nulo");
            if (_context.Inscricoes == null)
                return Content("DbSet<Inscricoes> nulo");

            var inscricoes = await _context.Inscricoes.ToListAsync();
            return View(inscricoes);
        }


        // GET: Inscricaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscricao = await _context.Inscricoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inscricao == null)
            {
                return NotFound();
            }

            return View(inscricao);
        }

        // GET: Inscricaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inscricaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Telefone,Categoria,Atividades")] Inscricao inscricao)
        {
            if (inscricao.Categoria == "Sócio")
                inscricao.Valor = 220m;
            else if (inscricao.Categoria == "Não Sócio")
                inscricao.Valor = 400m;

            if (ModelState.IsValid)
            {
                _context.Add(inscricao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inscricao);
        }



        // GET: Inscricaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscricao = await _context.Inscricoes.FindAsync(id);
            if (inscricao == null)
            {
                return NotFound();
            }
            return View(inscricao);
        }
   

        // GET: Inscricaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscricao = await _context.Inscricoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inscricao == null)
            {
                return NotFound();
            }

            return View(inscricao);
        }

        // POST: Inscricaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inscricao = await _context.Inscricoes.FindAsync(id);
            if (inscricao != null)
            {
                _context.Inscricoes.Remove(inscricao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscricaoExists(int id)
        {
            return _context.Inscricoes.Any(e => e.Id == id);
        }
    }
}
