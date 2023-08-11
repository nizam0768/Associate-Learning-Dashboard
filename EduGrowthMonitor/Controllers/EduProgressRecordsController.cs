using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EduGrowthMonitor.Data;
using EduGrowthMonitor.Models;
using Microsoft.AspNetCore.Authorization;

namespace EduGrowthMonitor.Controllers
{
    [Authorize]

    public class EduProgressRecordsController : Controller
    {
        private readonly EduGrowthMonitorContext _context;

        public EduProgressRecordsController(EduGrowthMonitorContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> EmpRecDisplay()
        {
            var EmpByDate = from m in _context.EduProgressRecord
                            select m;
            return View(EmpByDate);
        }
        
        int TotoalHours;
        // GET: EduProgressRecords
        public async Task<IActionResult> Index(int SearchId, string EmpDomain, DateTime SerchByDate, DateTime SerchByDate2, int WeekelyHours)
        {
            if(_context.EduProgressRecord == null)
            {
                return Problem("Entity set 'EduProgressRecordContext.Record' is null");
            }
            IQueryable<string> GetDomain = from m in _context.EduProgressRecord
                                           orderby m.Domain
                                           select m.Domain;
            var EmpByDate = from m in _context.EduProgressRecord
                            select m;
            if (!string.IsNullOrEmpty(EmpDomain))
            {
                EmpByDate = EmpByDate.Where(x => x.Domain == EmpDomain);
            }
            if (SearchId != null)
            {
                EmpByDate = EmpByDate.Where(x => x.Emp_ID.Equals(SearchId));
                
            }
            if (SerchByDate != null)
            {
                //  EmpByDate = EmpByDate.Where(x => x.Login_Date.Equals(SerchByDate));

                EmpByDate = EmpByDate.Where(x => x.Date >= SerchByDate && x.Date <= SerchByDate2);
                TotoalHours = EmpByDate.Sum(z => z.Hours);
                

            }

            var EmpFilterVM = new GetEmployeeByDomain
            {
                EmployeeByDomain = new SelectList(await GetDomain.Distinct().ToListAsync()),
                WeekelyHours = TotoalHours,
                EduProgressRecords = await EmpByDate.ToListAsync()
        };

            
            return View(EmpFilterVM);

            /*
            return _context.EduProgressRecord != null ? 
                          View(await _context.EduProgressRecord.ToListAsync()) :
                          Problem("Entity set 'EduGrowthMonitorContext.EduProgressRecord'  is null.");
            */
        }
        [Authorize(Roles = "Admin,Manager, Trainee")]
        // GET: EduProgressRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EduProgressRecord == null)
            {
                return NotFound();
            }

            var eduProgressRecord = await _context.EduProgressRecord
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eduProgressRecord == null)
            {
                return NotFound();
            }

            return View(eduProgressRecord);
        }
        
        // GET: EduProgressRecords/Create
        [Authorize(Roles = "Admin,Trainee")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: EduProgressRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Emp_ID,Domain,Date,Task,Deatils,Hours,Comments")] EduProgressRecord eduProgressRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eduProgressRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(EmpRecDisplay));
            }
            return View(eduProgressRecord);
        }
        [Authorize(Roles = "Admin,Manager")]
        // GET: EduProgressRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EduProgressRecord == null)
            {
                return NotFound();
            }

            var eduProgressRecord = await _context.EduProgressRecord.FindAsync(id);
            if (eduProgressRecord == null)
            {
                return NotFound();
            }
            return View(eduProgressRecord);
        }

        // POST: EduProgressRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Emp_ID,Domain,Date,Task,Deatils,Hours,Comments")] EduProgressRecord eduProgressRecord)
        {
            if (id != eduProgressRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eduProgressRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EduProgressRecordExists(eduProgressRecord.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(EmpRecDisplay));
            }
            return View(eduProgressRecord);
        }

        // GET: EduProgressRecords/Delete/5
        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EduProgressRecord == null)
            {
                return NotFound();
            }

            var eduProgressRecord = await _context.EduProgressRecord
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eduProgressRecord == null)
            {
                return NotFound();
            }

            return View(eduProgressRecord);
        }

        // POST: EduProgressRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EduProgressRecord == null)
            {
                return Problem("Entity set 'EduGrowthMonitorContext.EduProgressRecord'  is null.");
            }
            var eduProgressRecord = await _context.EduProgressRecord.FindAsync(id);
            if (eduProgressRecord != null)
            {
                _context.EduProgressRecord.Remove(eduProgressRecord);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(EmpRecDisplay));
        }

        private bool EduProgressRecordExists(int id)
        {
          return (_context.EduProgressRecord?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
