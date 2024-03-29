﻿using VelvetLeaves.Data.Models;
using VelvetLeaves.ViewModels.Colors;
using VelvetLeaves.ViewModels.Material;
using VelvetLeaves.ViewModels.Product.Enums;
using VelvetLeaves.ViewModels.Tag;

namespace VelvetLeaves.ViewModels.Product
{
    public class ProductsQueryModel
    {
        public ProductsSorting ProductsSorting { get; set; }
        public IEnumerable<int> ColorIds { get; set; } = new HashSet<int>();
        public IEnumerable<int> Materials { get; set; } = new HashSet<int>();
        public IEnumerable<string> Tags { get; set; } = new HashSet<string>();
        public string? SearchString { get; set; }
        public int ProductsPerPage { get; set; } = 6;
        public int TotalProducts { get; set; }
        public int MaxPages { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public IEnumerable<ColorSelectViewModel> ColorOptions { get; set; } = new HashSet<ColorSelectViewModel>();
        public IEnumerable<MaterialListViewModel> MaterialOptions { get; set; } = new HashSet<MaterialListViewModel>();
        public IEnumerable<TagListViewModel> TagOptions { get; set; } = new HashSet<TagListViewModel>();

        public IEnumerable<ProductListViewModel> Products { get; set; } = new HashSet<ProductListViewModel>();
    }
}
