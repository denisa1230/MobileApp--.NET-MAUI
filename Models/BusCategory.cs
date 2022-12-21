namespace Proiect.Models
{
    public class BusCategory
    {
        public int ID { get; set; }
        public int BusID { get; set; }
        public Bus Bus { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
