

namespace VelvetLeaves.ViewModels.ProductSeries
{
    public class ProductSeriesDefaultValues
    {
        public IEnumerable<int> ColorIds { get; set; } = new HashSet<int>();
        public IEnumerable<int> MaterialIds { get; set; } = new HashSet<int>();
        public IEnumerable<int> TagIds { get; set; } = new HashSet<int>();

        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }


    }
}
