using System.Security.Policy;

namespace Proiect.Models.ViewModels
{
    public class DepartureIndexData
    {
        public IEnumerable<Departure> Departures{ get; set; }
        public IEnumerable<Bus> Buses { get; set; }

    }
}
