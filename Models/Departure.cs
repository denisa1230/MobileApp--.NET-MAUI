namespace Proiect.Models
{
    public class Departure
    {
        public int ID { get; set; }
        public string DepartureName { get; set; }
        public ICollection<Bus>? Buses { get; set; }
    }
}
