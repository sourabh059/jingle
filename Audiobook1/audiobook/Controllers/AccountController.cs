using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using audiobook.Models;
using System.Collections.Generic;
using bol;
using dal;
namespace audiobook.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
      ViewBag.Message = "File uploaded successfully.";

      Dbmanager db=new Dbmanager();
        List<Mp3saver> alist=db.getallaudio();
         this.ViewData["mp3"]=alist;
        return View();
    }

    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
