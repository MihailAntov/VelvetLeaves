using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelvetLeaves.ViewModels.Category;
using VelvetLeaves.ViewModels.Colors;
using VelvetLeaves.ViewModels.Material;
using VelvetLeaves.ViewModels.ProductSeries;
using VelvetLeaves.ViewModels.Subcategory;
using VelvetLeaves.ViewModels.Tag;

namespace VelvetLeaves.ViewModels.Product
{
    public class ProductEditFormViewModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        public int ProductSeriesId { get; set; }

        [Required]
        public IEnumerable<IFormFile> Images { get; set; } = null!;
        public IEnumerable<string>? ImageIds { get; set; }


        public IEnumerable<int> ColorIds { get; set; } = new HashSet<int>();
        public IEnumerable<int> MaterialIds { get; set; } = new HashSet<int>();
        public IEnumerable<int> TagIds { get; set; } = new HashSet<int>();

        public IEnumerable<ColorSelectViewModel> ColorOptions { get; set; } = new HashSet<ColorSelectViewModel>();

        public IEnumerable<MaterialListViewModel> MaterialOptions { get; set; } = new HashSet<MaterialListViewModel>();
        public IEnumerable<TagListViewModel> TagOptions { get; set; } = new HashSet<TagListViewModel>();

    }
}
