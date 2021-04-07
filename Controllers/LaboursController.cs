using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LabourZillaZoneee.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace LabourZillaZoneee.Controllers
{
    
    public class LaboursController : Controller
    {
        private readonly LabourZillaZoneContext _context;
        private readonly IWebHostEnvironment _hostEnviroment;

        public LaboursController(LabourZillaZoneContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnviroment = hostEnvironment;
        }

        // GET: Labours
        public async Task<IActionResult> Index()
        {
            return View(await _context.Labours.ToListAsync());
        }
        
        // GET: Labours/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labour = await _context.Labours
                .FirstOrDefaultAsync(m => m.Id == id);
            if (labour == null)
            {
                return NotFound();
            }

            return View(labour);
        }
        [Authorize]
        // GET: Labours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Labours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Pswd,Cnfrmpswd,Profession,CityAddress,StateL,DailyWages,TimeDate,Available,Lcontact,Ppic,PPicFile,RoleL")] Labour labour)
        {
            if (ModelState.IsValid)
            {
                string rootPath = _hostEnviroment.WebRootPath;
                string fileName = Path.GetFileName(labour.PPicFile.FileName) ;

                string pPath = Path.Combine(rootPath + "/Images/", fileName);
                labour.Ppic = fileName;
                var filStream = new FileStream(pPath, FileMode.Create);
                await labour.PPicFile.CopyToAsync(filStream);
                filStream.Close();
                _context.Add(labour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(labour);
        }

        // GET: Labours/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labour = await _context.Labours.FindAsync(id);
            if (labour == null)
            {
                return NotFound();
            }
            return View(labour);
        }

        // POST: Labours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,FirstName,LastName,Pswd,Cnfrmpswd,Profession,CityAddress,StateL,DailyWages,TimeDate,Available,Lcontact,Ppic,RoleL")] Labour labour)
        {
            if (id != labour.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(labour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabourExists(labour.Id))
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
            return View(labour);
        }

        // GET: Labours/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labour = await _context.Labours
                .FirstOrDefaultAsync(m => m.Id == id);
            if (labour == null)
            {
                return NotFound();
            }

            return View(labour);
        }

        // POST: Labours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var labour = await _context.Labours.FindAsync(id);
            _context.Labours.Remove(labour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabourExists(string id)
        {
            return _context.Labours.Any(e => e.Id == id);
        }
    }
}
