using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;
using Proiect.Models.ViewModels;

namespace Proiect.Pages.Departures
{
    public class IndexModel : PageModel
    {
        private readonly Proiect.Data.ProiectContext _context;

        public IndexModel(Proiect.Data.ProiectContext context)
        {
            _context = context;
        }

        public IList<Departure> Departure { get; set; } = default!;

        public DepartureIndexData DepartureData { get; set; }
        public int DepartureID { get; set; }
        public int BusID { get; set; }
        public async Task OnGetAsync(int? id, int? busID)
        {
            DepartureData = new DepartureIndexData();
            DepartureData.Departures = await _context.Departure
            .Include(i => i.Buses)
            .OrderBy(i => i.DepartureName)
            .ToListAsync();
            if (id != null)
            {
                DepartureID = id.Value;
                Departure departure = DepartureData.Departures
                .Where(i => i.ID == id.Value).Single();
                DepartureData.Buses = departure.Buses;
            }
        }
    }
}
