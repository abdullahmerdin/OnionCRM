using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnionCRM.WebUI.Models;

namespace OnionCRM.WebUI.Controllers;

public class HomeController : Controller
{
    private readonly Serilog.ILogger _logger;

    public HomeController(Serilog.ILogger logger)
    {
        _logger = logger;
    }
    [AllowAnonymous]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        _logger.Error("@{MethodName} - {Message}", nameof(Error), "Error");
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}