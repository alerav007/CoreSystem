using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoreSystem.Data;
using CoreSystem.Models;
using System.Threading.Tasks;
using System.Linq;

namespace CoreSystem.Controllers
{
    public class EntradasController : Controller
    {
        private readonly AppDbContext _context;

        public EntradasController(AppDbContext context)
        {
            _context = context;
        }

        // Muestra la lista de entradas
        public IActionResult Index()
        {
            var entradas = _context.Entradas.ToList();
            return View(entradas);
        }

        public IActionResult Create()
        {
            ViewBag.Productos = new SelectList(_context.Productos, "IdProducto", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Entrada entrada)
        {
            if (ModelState.IsValid)
            {
                _context.Entradas.Add(entrada);

                // Actualiza stock en Productos
                var producto = await _context.Productos.FindAsync(entrada.IdProducto);
                if (producto != null)
                {
                    producto.CantidadEnStock += entrada.Cantidad;
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Entradas");
            }

            ViewBag.Productos = new SelectList(_context.Productos, "IdProducto", "Nombre", entrada.IdProducto);
            return View(entrada);
        }
    }
}