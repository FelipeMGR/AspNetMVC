using AspNetMVC.Context;
using AspNetMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AspNetMVC.Controllers
{
    public class ContactController : Controller
    {

        private readonly AgendaContext _context;

        public ContactController(AgendaContext context)
        {
            _context = context;
        }

        public IActionResult Contact()
        {
            var contatos = _context.Contacts.ToList();
            return View(contatos);
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if(ModelState.IsValid)
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                return RedirectToAction(nameof(Contact));
            }
            return View(contact);
        }
        public IActionResult Edit(int id)
        {
            var contact = _context.Contacts.Find(id);

            if (contact is null)
            {
                return RedirectToAction(nameof(Contact));
            }

            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            var contactDB = _context.Contacts.Find(contact.Id);

            contactDB.Name = contact.Name;
            contactDB.PhoneNumber = contact.PhoneNumber;
            contactDB.Active = contact.Active;

            _context.Contacts.Update(contactDB);
            _context.SaveChanges();
            return RedirectToAction(nameof(Contact));
        }

        public IActionResult Details(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact is null)
                return RedirectToAction(nameof(Contact));
            return View(contact);
        }

        public IActionResult Delete(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact is null)
                return RedirectToAction(nameof(Contact));

            return View(contact);
        }

        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            var contactDeleted = _context.Contacts.Find(contact.Id);

            if (contactDeleted is null)
                return RedirectToAction(nameof(Contact));

            contactDeleted.Name = contact.Name;
            contactDeleted.PhoneNumber = contact.PhoneNumber;
            contactDeleted.Active = contact.Active;

            _context.Contacts.Remove(contactDeleted);
            _context.SaveChanges();
            return RedirectToAction(nameof(Contact));
        }
    }
}
