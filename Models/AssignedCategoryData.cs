using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect.Data;
namespace Proiect.Models

{
    public class AssignedCategoryData
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public bool Assigned { get; set; }
    }
}
