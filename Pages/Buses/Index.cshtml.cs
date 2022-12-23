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

        public IList<Bus> Bus { get; set; } = default!;
        public BusData BusD { get; set; }
        public int BusID { get; set; }
        public int CategoryID { get; set; }
        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {
            BusD = new BusData();
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            BusD.Buses = await _context.Bus
            .Include(b => b.Arrival)
            .Include(b => b.Departure)
            .Include(b => b.BusCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                BusD.Buses = BusD.Buses.Where(s => s.Name.Contains(searchString)

               || s.Name.Contains(searchString));
            }

                if (id != null)
            {
                BusID = id.Value;
                Bus bus = BusD.Buses
                .Where(i => i.ID == id.Value).Single();
                BusD.Categories = bus.BusCategories.Select(s => s.Category);
            }
            switch (sortOrder)
            {
                case "name_desc":
                    BusD.Buses = BusD.Buses.OrderByDescending(s =>
                   s.Name);
                    break;


            }

        }
    }
}
