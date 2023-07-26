﻿

using VelvetLeaves.ViewModels.Category;
using VelvetLeaves.ViewModels.Colors;
using VelvetLeaves.ViewModels.Material;
using VelvetLeaves.ViewModels.Subcategory;
using VelvetLeaves.ViewModels.Tag;

namespace VelvetLeaves.ViewModels.ProductSeries
{
    public class ProductSeriesFormViewModel
    {
        public string Name { get; set; } = null!;

        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }

        public string DefaultName { get; set; } = null!;
        public decimal DefaultPrice { get; set; }
        public string DefaultDescription { get; set; } = null!;

        public IEnumerable<int> DefaultColorIds { get; set; } = new HashSet<int>();
        public IEnumerable<int> DefaultMaterialIds { get; set; } = new HashSet<int>();
        public IEnumerable<int> DefaultTagIds { get; set; } = new HashSet<int>();



        public IEnumerable<ColorSelectViewModel> ColorOptions { get; set; } = new HashSet<ColorSelectViewModel>();
        public IEnumerable<CategorySelectViewModel> CategoryOptions { get; set; } = new HashSet<CategorySelectViewModel>();
        public IEnumerable<SubcategorySelectViewModel> SubcategoryOptions { get; set; } = new HashSet<SubcategorySelectViewModel>();
        public IEnumerable<MaterialListViewModel> MaterialOptions { get; set; } = new HashSet<MaterialListViewModel>();
        public IEnumerable<TagListViewModel> TagOptions { get; set; } = new HashSet<TagListViewModel>();
    }
}
