using Microsoft.AspNetCore.Mvc;
using MVC_FirstPracticeCRUD.Data;
using MVC_FirstPracticeCRUD.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Immutable;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MVC_FirstPracticeCRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contacts.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contacto = _context.Contacts.Find(id);
            if(contacto == null)
            {
                return NotFound();
            }
            else
            {
                return View(contacto);
            }
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contacto = _context.Contacts.Find(id);
            if (contacto == null)
            {
                return NotFound();
            }
            else
            {
                return View(contacto);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Update(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contact = _context.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }
            else
            {
                return View(contact);
            }

        }
        [HttpPost]
        public async Task<IActionResult> Delete(Contact contact)
        {
                _context.Remove(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}