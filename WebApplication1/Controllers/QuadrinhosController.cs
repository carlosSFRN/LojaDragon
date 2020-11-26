using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using SQLitePCL;

namespace WebApplication1.Controllers
{
    public class QuadrinhosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public QuadrinhosController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Quadrinhos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Quadrinho.ToListAsync());
        }

        // GET: Quadrinhos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quadrinho = await _context.Quadrinho
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quadrinho == null)
            {
                return NotFound();
            }

            return View(quadrinho);
        }

        // GET: Quadrinhos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Quadrinhos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descricao,Preco,Quantidade,CaminhoCapa")] Quadrinho quadrinho)
        {
            if (ModelState.IsValid)
            {

                //salvar img no diretorio img
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(quadrinho.CaminhoCapa.FileName);
                string extension = Path.GetExtension(quadrinho.CaminhoCapa.FileName);
                string path = Path.Combine(wwwRootPath + "\\img", fileName + extension);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await quadrinho.CaminhoCapa.CopyToAsync(fileStream);
                }

                quadrinho.CaminhoFisicoCapa = "\\img\\" + fileName + extension;
                Convert.ToDecimal(quadrinho.Preco).ToString("N2");

                _context.Add(quadrinho);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quadrinho);
        }

        // GET: Quadrinhos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quadrinho = await _context.Quadrinho.FindAsync(id);
            if (quadrinho == null)
            {
                return NotFound();
            }
            return View(quadrinho);
        }

        // POST: Quadrinhos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descricao,Preco,Quantidade,CaminhoCapa")] Quadrinho quadrinho)
        {
            if (id != quadrinho.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quadrinho);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuadrinhoExists(quadrinho.Id))
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
            return View(quadrinho);
        }

        // GET: Quadrinhos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quadrinho = await _context.Quadrinho
                .FirstOrDefaultAsync(m => m.Id == id);
            if (quadrinho == null)
            {
                return NotFound();
            }

            return View(quadrinho);
        }

        // POST: Quadrinhos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quadrinho = await _context.Quadrinho.FindAsync(id);
            _context.Quadrinho.Remove(quadrinho);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuadrinhoExists(int id)
        {
            return _context.Quadrinho.Any(e => e.Id == id);
        }
    }
}
