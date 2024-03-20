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

        [HttpGet]
        public IActionResult Index(string search)
        {
            IQueryable<Contact> contactsQuery = _ctx.Contacts.Include(c => c.Category).OrderBy(c => c.LastName);

            if (!string.IsNullOrEmpty(search))
            {
                contactsQuery = contactsQuery.Where(c => c.LastName.Contains(search)
                                                       || c.FirstName.Contains(search)
                                                       || c.Email.Contains(search)
                                                       || c.PhoneNumber.Contains(search)
                                                       || c.Category.Name.Contains(search));
            }

            var contacts = contactsQuery.ToList();

            return View(contacts);
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
