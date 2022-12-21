namespace Proiect.Models
{
    public class BusData
    {
        public IEnumerable<Bus> Buses { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<BusCategory> BusCategories { get; set; }

    }
}
