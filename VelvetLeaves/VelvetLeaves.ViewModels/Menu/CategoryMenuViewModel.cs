using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelvetLeaves.ViewModels.Menu
{
    public class CategoryMenuViewModel
    {
        public string Name { get; set; } = null!;
        public int Id { get; set; }
        public string ImageUrl { get; set; } = null!;
        public ICollection<SubcategoryMenuViewModel> Subcategories { get; set; } = new HashSet<SubcategoryMenuViewModel>();
    }
}
