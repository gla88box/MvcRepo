using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoProject.Data;
using DemoProject.Extensions;
using DemoProject.Models;

namespace DemoProject.Controllers
{
    public class AddressesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get: Addresses For Person
        public async Task<IActionResult> Index(Guid? personId)
        {
            if (!personId.HasValue)
            {
                return View(new Person());
            }

            var person = await _context.Person.FirstOrDefaultAsync(p => p.Id == personId);
            if(person == null)
            {
                return NotFound();
            }

            person.Addresses = _context.Address.Where(a => a.PersonId == person.Id).ToList();

            return View(person);
        }

        // GET: Addresses/Details/
        public async Task<IActionResult> Details(Guid? addressId)
        {
            if (!addressId.HasValue)
            {
                return NotFound();
            }

            var address = await _context.Address.FirstOrDefaultAsync(m => m.Id == addressId);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // GET: Addresses/Create
        public IActionResult Create(Guid? personId)
        {
            return View(new Address { PersonId = personId.GetValueOrDefault() });
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Line1,Line2,Town,County,Postcode,DateUsedFrom,DateUsedTo,IsCorrespondence,IsBilling,IsActive,PersonId")] Address address)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    address.SetCreateDefaultSettings();
                    _context.Add(address);
                    await _context.SaveChangesAsync();
                    
                    return RedirectToAction("Index", new { personId = address.PersonId });
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }

            return View(null);
        }

        // GET: Addresses/Edit/
        public async Task<IActionResult> Edit(Guid? addressId)
        {
            if (addressId == null)
            {
                return NotFound();
            }

            var address = await _context.Address.FindAsync(addressId);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Addresses/Edit/
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Line1,Line2,Town,County,Postcode,DateUsedFrom,DateUsedTo,IsCorrespondence,IsBilling,Id,CreatedOn,IsActive,PersonId")] Address address)
        {
            if (id != address.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(address);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressExists(address.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", new { personId = address.PersonId });
            }

            return View(address);
        }

        // GET: Addresses/Delete/
        public async Task<IActionResult> Delete(Guid? addressId)
        {
            if (addressId == null)
            {
                return NotFound();
            }

            var address = await _context.Address.FirstOrDefaultAsync(m => m.Id == addressId);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Addresses/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            Guid? personId;
            try
            {
                var address = await _context.Address.FindAsync(id);
                personId = address.PersonId;
                _context.Address.Remove(address);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return RedirectToAction("Index", new { personId = personId.GetValueOrDefault() });
        }

        private bool AddressExists(Guid id)
        {
            return _context.Address.Any(e => e.Id == id);
        }
    }
}
