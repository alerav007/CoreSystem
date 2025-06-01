// Controllers/LoginController.cs
using Microsoft.AspNetCore.Mvc;
using CoreSystem.Data;
using System.Linq;

namespace CoreSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
    {
        return View();
    }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.LoginName == username && u.Password == password);
            if (user != null)
            {
                HttpContext.Session.SetString("Usuario", user.Nombre);
                HttpContext.Session.SetString("Role", user.Cargo);
                
                return RedirectToAction("Dashboard", "Home");

            }

            ViewBag.Error = "Usuario o contraseña incorrectos.";
            return View();
        }

        public IActionResult Dashboard()
{
    var rol = HttpContext.Session.GetString("Role");
    if (rol == null)
    {
        return RedirectToAction("Index", "Login");
    }

    ViewBag.Usuario = HttpContext.Session.GetString("Usuario");
    ViewBag.Role = rol;

    return View("~/Views/Home/Dashboard.cshtml");
}
    }
}
