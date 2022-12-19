using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Departures
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public DetailsModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

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
    }
}
