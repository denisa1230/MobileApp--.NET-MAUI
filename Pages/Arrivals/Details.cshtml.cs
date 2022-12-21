using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Arrivals
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public DetailsModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

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
    }
}
