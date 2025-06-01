using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CoreSystem.Models;

namespace CoreSystem.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
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

    return View();
}

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
        public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Login");
    }
}

