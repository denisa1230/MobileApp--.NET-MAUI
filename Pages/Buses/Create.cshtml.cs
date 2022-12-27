using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
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
    public class CreateModel : BusCategoriesPageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public CreateModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DepartureID"] = new SelectList(_context.Set<Departure>(), "ID", "DepartureName");
            ViewData["ArrivalID"] = new SelectList(_context.Set<Arrival>(), "ID", "ArrivalName");
           

            var bus = new Bus();
            bus.BusCategories = new List<BusCategory>();
            PopulateAssignedCategoryData(_context, bus);
            return Page();
        }
        

        [BindProperty]
        public Bus Bus { get; set; }


      
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newBus = new Bus();
            if (selectedCategories != null)
            {
                newBus.BusCategories = new List<BusCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BusCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newBus.BusCategories.Add(catToAdd);
                }
            }
            Bus.BusCategories = newBus.BusCategories;
            _context.Bus.Add(Bus);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
            PopulateAssignedCategoryData(_context, newBus);
            return Page();
        }
    }
        
}


