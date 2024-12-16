using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MinhasNotas.Data;
using MinhasNotas.Models;

namespace MinhasNotas.Controllers
{
    public class GradesController : Controller
    {
        private readonly MinhasNotasContext _context;

        public GradesController(MinhasNotasContext context)
        {
            _context = context;
        }

        // GET: Grades
        public async Task<IActionResult> Index()
        {
            var minhasNotasContext = _context.Grades.Include(g => g.Student).Include(g => g.Subject);
            return View(await minhasNotasContext.ToListAsync());
        }

        // GET: Grades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Grades == null)
            {
                return NotFound();
            }

            var grades = await _context.Grades
                .Include(g => g.Student)
                .Include(g => g.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grades == null)
            {
                return NotFound();
            }

            return View(grades);
        }

        // GET: Grades/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Name");
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Name");
            return View();
        }

        // POST: Grades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Grade,DataTest,StudentId,SubjectId")] Grades grades)
        {
            //if (ModelState.IsValid)
            //{
             grades.Grade = Convert.ToDouble(grades.Grade.ToString("F2"));
            _context.Add(grades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
           // ViewData["StudentId"] = new SelectList(_context.Student, "Id", "EmailAddress", grades.StudentId);
            //ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Id", grades.SubjectId);
            //return View(grades);
        }

        // GET: Grades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Grades == null)
            {
                return NotFound();
            }

            var grades = await _context.Grades.FindAsync(id);
            if (grades == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Name", grades.StudentId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Name", grades.SubjectId);
            return View(grades);
        }

        // POST: Grades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Grade,DataTest,StudentId,SubjectId")] Grades grades)
        {
            if (id != grades.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
                try
                {
                grades.Grade = Convert.ToDouble(grades.Grade.ToString("F2"));
                _context.Update(grades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GradesExists(grades.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
           // }
           // ViewData["StudentId"] = new SelectList(_context.Student, "Id", "EmailAddress", grades.StudentId);
            //ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Id", grades.SubjectId);
            //return View(grades);
        }

        // GET: Grades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Grades == null)
            {
                return NotFound();
            }

            var grades = await _context.Grades
                .Include(g => g.Student)
                .Include(g => g.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grades == null)
            {
                return NotFound();
            }

            return View(grades);
        }

        // POST: Grades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Grades == null)
            {
                return Problem("Entity set 'MinhasNotasContext.Grades'  is null.");
            }
            var grades = await _context.Grades.FindAsync(id);
            if (grades != null)
            {
                _context.Grades.Remove(grades);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GradesExists(int id)
        {
            return (_context.Grades?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
