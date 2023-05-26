using ElizabethRobinsonDiaryEntries.Data;
using ElizabethRobinsonDiaryEntries.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElizabethRobinsonDiaryEntries.Controllers
{
    public class DiaryEntriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DiaryEntriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DiaryEntries
        public async Task<IActionResult> Index()
        {
            return View(await _context.DiaryEntries.ToListAsync());
        }

        // GET: DiaryEntries/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // PoST: DiaryEntries/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(string searchPhrase)
        {
            return View("Index", await _context.DiaryEntries.Where(x => x.EntryContext.Contains(searchPhrase)).ToListAsync());
        }

        // GET: DiaryEntries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DiaryEntries == null)
            {
                return NotFound();
            }

            var diaryEntries = await _context.DiaryEntries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diaryEntries == null)
            {
                return NotFound();
            }

            return View(diaryEntries);
        }

        // GET: DiaryEntries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DiaryEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EntryName,EntryDate,EntryContext")] DiaryEntries diaryEntries)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diaryEntries);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(diaryEntries);
        }

        // GET: DiaryEntries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DiaryEntries == null)
            {
                return NotFound();
            }

            var diaryEntries = await _context.DiaryEntries.FindAsync(id);
            if (diaryEntries == null)
            {
                return NotFound();
            }
            return View(diaryEntries);
        }

        // POST: DiaryEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EntryName,EntryDate,EntryContext")] DiaryEntries diaryEntries)
        {
            if (id != diaryEntries.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diaryEntries);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiaryEntriesExists(diaryEntries.Id))
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
            return View(diaryEntries);
        }

        // GET: DiaryEntries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DiaryEntries == null)
            {
                return NotFound();
            }

            var diaryEntries = await _context.DiaryEntries
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diaryEntries == null)
            {
                return NotFound();
            }

            return View(diaryEntries);
        }

        // POST: DiaryEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DiaryEntries == null)
            {
                return Problem("Entity set 'ApplicationDbContext.DiaryEntries'  is null.");
            }
            var diaryEntries = await _context.DiaryEntries.FindAsync(id);
            if (diaryEntries != null)
            {
                _context.DiaryEntries.Remove(diaryEntries);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiaryEntriesExists(int id)
        {
            return (_context.DiaryEntries?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
