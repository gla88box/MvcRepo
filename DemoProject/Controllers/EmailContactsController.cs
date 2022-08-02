using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoProject.Data;
using DemoProject.Models;

namespace DemoProject.Controllers
{
    public class EmailContactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmailContactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmailContacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmailContact.ToListAsync());
        }

        // GET: EmailContacts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emailContact = await _context.EmailContact
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emailContact == null)
            {
                return NotFound();
            }

            return View(emailContact);
        }

        // GET: EmailContacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmailContacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmailAddress,IsMarketable,DateUsedFrom,DateUsedTo,Id,CreatedOn,IsActive")] EmailContact emailContact)
        {
            if (ModelState.IsValid)
            {
                emailContact.Id = Guid.NewGuid();
                _context.Add(emailContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emailContact);
        }

        // GET: EmailContacts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emailContact = await _context.EmailContact.FindAsync(id);
            if (emailContact == null)
            {
                return NotFound();
            }
            return View(emailContact);
        }

        // POST: EmailContacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("EmailAddress,IsMarketable,DateUsedFrom,DateUsedTo,Id,CreatedOn,IsActive")] EmailContact emailContact)
        {
            if (id != emailContact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emailContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmailContactExists(emailContact.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(emailContact);
        }

        // GET: EmailContacts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emailContact = await _context.EmailContact
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emailContact == null)
            {
                return NotFound();
            }

            return View(emailContact);
        }

        // POST: EmailContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var emailContact = await _context.EmailContact.FindAsync(id);
            _context.EmailContact.Remove(emailContact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmailContactExists(Guid id)
        {
            return _context.EmailContact.Any(e => e.Id == id);
        }
    }
}
