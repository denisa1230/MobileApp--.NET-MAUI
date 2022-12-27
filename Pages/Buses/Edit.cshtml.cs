using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;



namespace Proiect.Pages.Buses
{
    [Authorize(Roles = "Admin")]
    public class EditModel : BusCategoriesPageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public EditModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bus Bus { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            Bus = await _context.Bus
           .Include(b => b.Arrival)
           .Include(b => b.Departure)
           .Include(b => b.BusCategories).ThenInclude(b => b.Category)
           .AsNoTracking()
           .FirstOrDefaultAsync(m => m.ID == id);

            

            if (Bus == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Bus);

         
            ViewData["DepartureID"] = new SelectList(_context.Set<Departure>(), "ID", "DepartureName");
            ViewData["ArrivalID"] = new SelectList(_context.Set<Arrival>(), "ID", "ArrivalName");
            return Page();
        }

        
        public async Task<IActionResult>  OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            var busToUpdate = await _context.Bus

            .Include(i => i.Arrival)
            .Include(i => i.Departure)
            .Include(i => i.BusCategories).ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);

            if (busToUpdate == null)
            {
                return NotFound();
            }
           
            if (await TryUpdateModelAsync<Bus>(
            busToUpdate,
            "Bus",
           
            i => i.Departure, i => i.Arrival, i => i.Name,
            i => i.ArrivalDates, i => i.DepartureDates, i => i.Price))
            {
                UpdateBusCategories(_context, selectedCategories, busToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
           
            UpdateBusCategories(_context, selectedCategories, busToUpdate);
            PopulateAssignedCategoryData(_context, busToUpdate);
            return Page();
        }
    }
}

