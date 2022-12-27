using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Departures
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public DeleteModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Departure Departure { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Departure == null)
            {
                return NotFound();
            }

            var departure = await _context.Departure.FirstOrDefaultAsync(m => m.ID == id);

            if (departure == null)
            {
                return NotFound();
            }
            else 
            {
                Departure = departure;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Departure == null)
            {
                return NotFound();
            }
            var departure = await _context.Departure.FindAsync(id);

            if (departure != null)
            {
                Departure = departure;
                _context.Departure.Remove(Departure);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
