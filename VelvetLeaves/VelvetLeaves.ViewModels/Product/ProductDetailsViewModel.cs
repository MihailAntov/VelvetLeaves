﻿namespace VelvetLeaves.ViewModels.Product
{
    public class ProductDetailsViewModel
    {

        public string Name { get; set; } = null!;
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public IEnumerable<string> Images { get; set; } = new HashSet<string>();
        public IEnumerable<ProductListViewModel> ProductSeries { get; set; } = new HashSet<ProductListViewModel>();

        public IEnumerable<string> Materials { get; set; } = new HashSet<string>();
        public IEnumerable<string> Tags { get; set; } = new HashSet<string>();

    }
}
