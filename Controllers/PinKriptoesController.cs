using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PinTest.Data;
using PinTest.Models;
using Microsoft.AspNetCore.Authorization;

namespace PinTest.Controllers
{

    [Authorize]

    public class PinKriptoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PinKriptoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PinKriptoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PinKripto.ToListAsync());
        }

        // GET: PinKriptoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pinKripto = await _context.PinKripto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pinKripto == null)
            {
                return NotFound();
            }

            return View(pinKripto);
        }

        // GET: PinKriptoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PinKriptoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Symbol,KriptoName,USD")] PinKripto pinKripto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pinKripto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pinKripto);
        }

        // GET: PinKriptoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pinKripto = await _context.PinKripto.FindAsync(id);
            if (pinKripto == null)
            {
                return NotFound();
            }
            return View(pinKripto);
        }

        // POST: PinKriptoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Symbol,KriptoName,USD")] PinKripto pinKripto)
        {
            if (id != pinKripto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pinKripto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PinKriptoExists(pinKripto.Id))
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
            return View(pinKripto);
        }

        // GET: PinKriptoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pinKripto = await _context.PinKripto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pinKripto == null)
            {
                return NotFound();
            }

            return View(pinKripto);
        }

        // POST: PinKriptoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pinKripto = await _context.PinKripto.FindAsync(id);
            _context.PinKripto.Remove(pinKripto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PinKriptoExists(int id)
        {
            return _context.PinKripto.Any(e => e.Id == id);
        }
    }
}
