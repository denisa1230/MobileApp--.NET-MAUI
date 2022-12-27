using System.ComponentModel.DataAnnotations;

namespace Proiect.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        public int? MemberID { get; set; }
        public Member? Member { get; set; }
        public int? BusID { get; set; }
        public Bus? Bus { get; set; }
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }
    }
}
