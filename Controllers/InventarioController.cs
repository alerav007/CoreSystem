using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CoreSystem.Data;

namespace CoreSystem.Controllers
{
    public class InventarioController : Controller
    {
        private readonly AppDbContext _context;

        public InventarioController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Entrada()
        {
            ViewBag.Productos = new SelectList(_context.Productos, "IdProducto", "Nombre");
            return View();
        }
    }
}