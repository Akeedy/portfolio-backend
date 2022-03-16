using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using portfolio_backend.Models;

namespace portfolio_backend.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _dbcontext;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext applicationDbContext)
    {
        _logger = logger;
        _dbcontext=applicationDbContext;
    }

    public IActionResult Index()
    {
        
        var projects=_dbcontext.Set<Project>().ToList();
        return View(projects);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
