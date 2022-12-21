using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public BusData BusD { get; set; }
        public int BusID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            BusD = new BusData();

            BusD.Buses = await _context.Bus
            .Include(b => b.Arrival)
            .Include(b => b.Departure)
            .Include(b => b.BusCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .ToListAsync();
            if (id != null)
            {
                BusID = id.Value;
                Bus bus = BusD.Buses
                .Where(i => i.ID == id.Value).Single();
                BusD.Categories = bus.BusCategories.Select(s => s.Category);
            }
        }

    }
}
