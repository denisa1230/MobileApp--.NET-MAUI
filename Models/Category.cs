namespace Proiect.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<BusCategory>? BusCategories { get; set; }
    }
}
