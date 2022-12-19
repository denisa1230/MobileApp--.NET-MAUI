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
    public class IndexModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public IndexModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public IList<Bus> Bus { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Bus != null)
            {
                Bus = await _context.Bus
                    .Include(b => b.Departure)
                    .ToListAsync();
            }
        }
    }
}
