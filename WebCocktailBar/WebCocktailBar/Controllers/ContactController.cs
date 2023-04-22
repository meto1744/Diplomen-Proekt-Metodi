using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebCocktailBar.Data;
using WebCocktailBar.Models.ContactUs;

namespace WebCocktailBar.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult ContactUs()
        {
            var message = new ContactMessage();
            return View(message);
        }
        [HttpPost]
        public ActionResult ContactUs(ContactMessage model)
        {
            if (ModelState.IsValid)
            {
                var sentMessage = new ContactMessage
                {
                    Comment = model.Comment,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };
                _context.ContactMessages.Add(sentMessage);
                _context.SaveChanges();

                return RedirectToAction("ContactUsResult", "Home");
            }
            return View();
        }
        public async Task<IActionResult> Index()
        {
            var messages = await _context.ContactMessages.ToListAsync();
            return View(messages);
        }
    }
}
