using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Buses
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public DetailsModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

      public Bus Bus { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bus == null)
            {
                return NotFound();
            }

            var bus = await _context.Bus.FirstOrDefaultAsync(m => m.ID == id);
            if (bus == null)
            {
                return NotFound();
            }
            else 
            {
                Bus = bus;
            }
            return Page();
        }
    }
}
