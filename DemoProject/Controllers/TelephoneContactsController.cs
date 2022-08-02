using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoProject.Data;
using DemoProject.Models;

namespace DemoProject.Controllers
{
    public class TelephoneContactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TelephoneContactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TelephoneContacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.TelephoneContact.ToListAsync());
        }

        // GET: TelephoneContacts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telephoneContact = await _context.TelephoneContact
                .FirstOrDefaultAsync(m => m.Id == id);
            if (telephoneContact == null)
            {
                return NotFound();
            }

            return View(telephoneContact);
        }

        // GET: TelephoneContacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TelephoneContacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TelephoneNumber,IsLandLine,ExtensionNumber,IsMarketable,DateUsedFrom,DateUsedTo,Id,CreatedOn,IsActive")] TelephoneContact telephoneContact)
        {
            if (ModelState.IsValid)
            {
                telephoneContact.Id = Guid.NewGuid();
                _context.Add(telephoneContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(telephoneContact);
        }

        // GET: TelephoneContacts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telephoneContact = await _context.TelephoneContact.FindAsync(id);
            if (telephoneContact == null)
            {
                return NotFound();
            }
            return View(telephoneContact);
        }

        // POST: TelephoneContacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TelephoneNumber,IsLandLine,ExtensionNumber,IsMarketable,DateUsedFrom,DateUsedTo,Id,CreatedOn,IsActive")] TelephoneContact telephoneContact)
        {
            if (id != telephoneContact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telephoneContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelephoneContactExists(telephoneContact.Id))
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
            return View(telephoneContact);
        }

        // GET: TelephoneContacts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telephoneContact = await _context.TelephoneContact
                .FirstOrDefaultAsync(m => m.Id == id);
            if (telephoneContact == null)
            {
                return NotFound();
            }

            return View(telephoneContact);
        }

        // POST: TelephoneContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var telephoneContact = await _context.TelephoneContact.FindAsync(id);
            _context.TelephoneContact.Remove(telephoneContact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelephoneContactExists(Guid id)
        {
            return _context.TelephoneContact.Any(e => e.Id == id);
        }
    }
}
