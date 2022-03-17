using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using portfolio_backend.EmailService;
using portfolio_backend.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace portfolio_backend.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _dbcontext;
    private readonly IEmailSender _emailSender;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext applicationDbContext,IEmailSender emailSender)
    {
        _logger = logger;
        _dbcontext=applicationDbContext;
        _emailSender=emailSender;
    }

    public IActionResult Index()
    {
    //    var message =new Message(new string[]{"mazlum.1472@gmail.com"},"Test email","This is the content from our email") ;
    //    _emailSender.SendEmail(message);
        var projects=_dbcontext.Set<Project>().ToList();
        return View(projects);
    }
    [HttpPost]
    public IActionResult SendEmail(GetInTouch getInTouch){
      if(!ModelState.IsValid)
        return Json(false);
       var message =new Message(new string[]{"mazlum-orhan@outlook.com"},getInTouch.Email+"-"+getInTouch.Name,getInTouch.Content) ;
       _emailSender.SendEmail(message);
       var jsonResult=JsonSerializer.Serialize(getInTouch.ToString());
       return Json(jsonResult); 
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
