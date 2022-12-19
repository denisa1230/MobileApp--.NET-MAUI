using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Xml.Linq;

namespace Proiect.Models
{
    public class Bus
    {
        public int ID { get; set; }
        
        public int? DepartureID { get; set; }
        public Departure? Departure { get; set; }
        [Display(Name = "The Place Of Arrival")]
        public string Arrival { get; set; }

        [Display(Name = "Arrival Date-Time")]
        [DataType(DataType.DateTime)]
        public DateTime ArrivalDates { get; set; }

        [Display(Name = "Departure Date-Time")]
        [DataType(DataType.DateTime)]

        public DateTime DepartureDates { get; set; }

        [Display(Name = "The Price Of The Trip")]

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        
    }
}
