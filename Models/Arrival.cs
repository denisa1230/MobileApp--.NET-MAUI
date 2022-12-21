using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proiect.Models
{
    public class Arrival
    {
        public int ID { get; set; }

        [Display(Name = "The Place Of Arrival")]
        public string ArrivalName { get; set; }
        public ICollection<Bus>? Buses { get; set; }
    }
}
