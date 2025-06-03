using Microsoft.AspNetCore.Mvc;
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
        public IActionResult VerInventario()
{
      var productos = _context.Productos.ToList();
    return View("~/Views/Inventario/VerInventario.cshtml", productos);
}
    }
}
