using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect.Data;
namespace Proiect.Models
{
    public class BusCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData( ProiectContext context, Bus bus)
        {
            var allCategories = context.Category;
            var busCategories = new HashSet<int>(
            bus.BusCategories.Select(c => c.CategoryID)); 
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = busCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateBusCategories(ProiectContext context, string[] selectedCategories, Bus busToUpdate)
        {
            if (selectedCategories == null)
            {
                busToUpdate.BusCategories = new List<BusCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var busCategories = new HashSet<int>
            (busToUpdate.BusCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!busCategories.Contains(cat.ID))
                    {
                        busToUpdate.BusCategories.Add(
                        new BusCategory
                        {
                            BusID = busToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (busCategories.Contains(cat.ID))
                    {
                        BusCategory courseToRemove
                        = busToUpdate
                        .BusCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }

    }
}
