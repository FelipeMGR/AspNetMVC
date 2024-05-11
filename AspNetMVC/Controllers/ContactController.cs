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

        [HttpPut]
        public IActionResult Edit(int id)
        {
            var contact = _context.Contacts.Find(id);

            if (contact is null)
            {
                return NotFound("The id does not exist.");
            }

            return View(contact);
        }
    }
}
