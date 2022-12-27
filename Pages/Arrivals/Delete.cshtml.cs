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

namespace Proiect.Pages.Arrivals
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
      public Arrival Arrival { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Arrival == null)
            {
                return NotFound();
            }

            var arrival = await _context.Arrival.FirstOrDefaultAsync(m => m.ID == id);

            if (arrival == null)
            {
                return NotFound();
            }
            else 
            {
                Arrival = arrival;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Arrival == null)
            {
                return NotFound();
            }
            var arrival = await _context.Arrival.FindAsync(id);

            if (arrival != null)
            {
                Arrival = arrival;
                _context.Arrival.Remove(Arrival);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
