using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebsiteExampleMain.Models;

namespace WebsiteExampleMain.Controllers
{
    public class StudentDetailsController : Controller
    {
        private readonly Student_Context _context;

        public StudentDetailsController(Student_Context context)
        {
            _context = context;
        }

        // GET: StudentDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.StudentDetails.ToListAsync());
        }

        // GET: StudentDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentDetails = await _context.StudentDetails
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (studentDetails == null)
            {
                return NotFound();
            }

            return View(studentDetails);
        }

        // GET: StudentDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentID,LastName,FirstName,Address,City")] StudentDetails studentDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentDetails);
        }

        // GET: StudentDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentDetails = await _context.StudentDetails.FindAsync(id);
            if (studentDetails == null)
            {
                return NotFound();
            }
            return View(studentDetails);
        }

        // POST: StudentDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentID,LastName,FirstName,Address,City")] StudentDetails studentDetails)
        {
            if (id != studentDetails.StudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentDetailsExists(studentDetails.StudentID))
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
            return View(studentDetails);
        }

        // GET: StudentDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentDetails = await _context.StudentDetails
                .FirstOrDefaultAsync(m => m.StudentID == id);
            if (studentDetails == null)
            {
                return NotFound();
            }

            return View(studentDetails);
        }

        // POST: StudentDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentDetails = await _context.StudentDetails.FindAsync(id);
            _context.StudentDetails.Remove(studentDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentDetailsExists(int id)
        {
            return _context.StudentDetails.Any(e => e.StudentID == id);
        }
    }
}
