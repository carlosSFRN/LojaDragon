using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CarrinhosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarrinhosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Carrinhos/Index/5
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quadrinho = await _context.Quadrinho
                .FirstOrDefaultAsync(m => m.IdQuadrinho == id);
            if (quadrinho == null)
            {
                return NotFound();
            }

            return View(quadrinho);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdQuadrinho,Titulo,Preco,Quantidade,IdSituacao")] Quadrinho quadrinho)
        {
           
            Compra compra = new Compra();


            if (quadrinho != null)
            {
                compra.Titulo = quadrinho.Titulo;
                compra.Preco = quadrinho.Preco;
                compra.Quantidade = quadrinho.Quantidade;

                compra.Usuario = User.Identity.Name;

                _context.Add(compra);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Compras");
            }
            
            return View(Index(quadrinho.IdQuadrinho));
        }

        // GET: Carrinhos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quadrinho = await _context.Quadrinho
                .FirstOrDefaultAsync(m => m.IdQuadrinho == id);
            if (quadrinho == null)
            {
                return NotFound();
            }

            return View(quadrinho);
        }

        // POST: Carrinhos/Delete/5
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
            return _context.Quadrinho.Any(e => e.IdQuadrinho == id);
        }
    }
}
