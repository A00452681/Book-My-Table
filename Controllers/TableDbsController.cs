using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Book_My_Table.Models;

namespace Book_My_Table.Controllers
{
    public class TableDbsController : Controller
    {
        private readonly CustomerReg _context;

        public TableDbsController(CustomerReg context)
        {
            _context = context;
        }

        // GET: TableDbs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TableDb.ToListAsync());
        }

        // GET: TableDbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableDb = await _context.TableDb
                .FirstOrDefaultAsync(m => m.TableDbId == id);
            if (tableDb == null)
            {
                return NotFound();
            }

            return View(tableDb);
        }

        // GET: TableDbs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TableDbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TableDbId,RestaurantId")] TableDb tableDb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tableDb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tableDb);
        }

        // GET: TableDbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableDb = await _context.TableDb.FindAsync(id);
            if (tableDb == null)
            {
                return NotFound();
            }
            return View(tableDb);
        }

        // POST: TableDbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TableDbId,RestaurantId")] TableDb tableDb)
        {
            if (id != tableDb.TableDbId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tableDb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableDbExists(tableDb.TableDbId))
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
            return View(tableDb);
        }

        // GET: TableDbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tableDb = await _context.TableDb
                .FirstOrDefaultAsync(m => m.TableDbId == id);
            if (tableDb == null)
            {
                return NotFound();
            }

            return View(tableDb);
        }

        // POST: TableDbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tableDb = await _context.TableDb.FindAsync(id);
            _context.TableDb.Remove(tableDb);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableDbExists(int id)
        {
            return _context.TableDb.Any(e => e.TableDbId == id);
        }
    }
}
