using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using audiobook.Models;
using System.IO;
using dal;
namespace audiobook.Controllers;

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
   
   [HttpPost]
   public IActionResult Add(IFormFile mp)
    {    
       try{
            string fnama= mp.FileName;
            Path.GetFileName(fnama);
            
       string uploadpath=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\mp3",fnama);
       var stream =new FileStream(uploadpath,FileMode.Create);
       mp.CopyToAsync(stream);
       Dbmanager db=new Dbmanager();

       string path="mp3/    "+fnama;  
       int value=db.addbook(fnama,path);

         
         
     

        Console.WriteLine(value);
       } catch(System.Exception err){
          
          Console.WriteLine(err);

       } 
      
        return RedirectToAction("Index", "Account");
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
