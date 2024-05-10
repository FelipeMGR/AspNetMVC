using AspNetMVC.Context;
using Microsoft.AspNetCore.Mvc;

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
    }
}
