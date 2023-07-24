namespace VelvetLeaves.ViewModels.Product
{
    public class ProductListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImageId { get; set; } = null!;
        public decimal Price { get; set; }

    }
}
