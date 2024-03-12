using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyContacts.Models;
using System.Diagnostics;

namespace MyContacts.Controllers
{
    public class HomeController : Controller
    {
        ContactContext _ctx;
        public HomeController(ContactContext ctx)
        {
            _ctx = ctx;
        }

        public IActionResult Index()
        {
            var contacts = _ctx.Contacts
                .Include(c => c.Category)
                .OrderBy(c => c.LastName)
                .ToList();
            return View(contacts);
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult Contact()
        {
            return View();
        }

        [Authorize]
        public IActionResult About()
        {
            return View();
        }

        [Authorize]
        public IActionResult Help()
        {
            return View();
        }

        [Authorize]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    //}
    //public class HomeController : Controller
    //{
    //    ContactContext _ctx;
    //    public HomeController(ContactContext ctx)
    //    {
    //           _ctx = ctx;
    //    }
        
    //    public IActionResult Index()
    //    {
    //        var contacts = _ctx.Contacts
    //            .Include(c => c.Category)
    //            .OrderBy(c => c.LastName)
    //            .ToList();
    //        return View(contacts);
    //    }

       
    //}
}
    }
