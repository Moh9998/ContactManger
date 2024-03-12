using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyContacts.Models;

namespace MyContacts.Controllers
{
    public class ContactController : Controller
    {
        ContactContext _ctx;

        public ContactController(ContactContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = _ctx.Categories.ToList();
            ViewBag.Action = "Add";
            return View("AddEdit", new Contact());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var contact = _ctx.Contacts.Find(id);
            ViewBag.Categories = _ctx.Categories.ToList();
            ViewBag.Action = "Edit";


            return View("AddEdit", contact);
        }

        [HttpPost]
        public IActionResult AddEdit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (contact.ContactId == 0)
                {
                    contact.DateAdded = DateTime.Now;
                    _ctx.Contacts.Add(contact);
                }
                else
                {
                    _ctx.Contacts.Update(contact);
                   
                }
                
                _ctx.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Categories = _ctx.Categories.ToList();
            return View(contact);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contact = _ctx.Contacts.Find(id);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            _ctx.Contacts
                .Remove(contact);
            _ctx.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var contact = _ctx.Contacts
                .Include(contact => contact.Category)
                .FirstOrDefault(c => c.ContactId == id);
            return View(contact);
        }
    }
}
