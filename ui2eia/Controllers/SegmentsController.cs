using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ui2eia.Models;

namespace ui2eia.Controllers
{
    public class SegmentsController : Controller
    {
        private readonly AccessContext _context;

        public SegmentsController(AccessContext context)
        {
            _context = context;
        }

        // GET: Segments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Segments.ToListAsync());
        }

        // GET: Segments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var segment = await _context.Segments
                .SingleOrDefaultAsync(m => m.SegmentId == id);
            if (segment == null)
            {
                return NotFound();
            }

            return View(segment);
        }

        // GET: Segments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Segments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SegmentId,Tag,Name,Access,State,Comment")] Segment segment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(segment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(segment);
        }

        // GET: Segments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var segment = await _context.Segments.SingleOrDefaultAsync(m => m.SegmentId == id);
            if (segment == null)
            {
                return NotFound();
            }
            return View(segment);
        }

        // POST: Segments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SegmentId,Tag,Name,Access,State,Comment")] Segment segment)
        {
            if (id != segment.SegmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(segment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SegmentExists(segment.SegmentId))
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
            return View(segment);
        }

        // GET: Segments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var segment = await _context.Segments
                .SingleOrDefaultAsync(m => m.SegmentId == id);
            if (segment == null)
            {
                return NotFound();
            }

            return View(segment);
        }

        // POST: Segments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var segment = await _context.Segments.SingleOrDefaultAsync(m => m.SegmentId == id);
            _context.Segments.Remove(segment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SegmentExists(int id)
        {
            return _context.Segments.Any(e => e.SegmentId == id);
        }
    }
}
