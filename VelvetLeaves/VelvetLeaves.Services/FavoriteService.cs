
using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Product;

namespace VelvetLeaves.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly VelvetLeavesDbContext _context;

        public FavoriteService(VelvetLeavesDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<ProductListViewModel>> GetFavoritesByUserIdAsync(string userId)
        {
            var model = await _context
                .Users
                .Include(u => u.Favorites)
                .Where(u => u.Id == userId)
                .Select(u => new List<ProductListViewModel>(u.Favorites
                    .Where(f=> f.IsActive)
                    .Select(f => new ProductListViewModel()
                    {
                        Id = f.Id,
                        Name = f.Name,
                        ImageId = f.Images.First().Id,
                        Price = f.Price
                    }))).FirstAsync();

            return model;



        }

        public async Task AddToFavorites(string userId, int productId)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (user == null || product == null)
            {
                return;
            }

            user.Favorites.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveFromFavorites(string userId, int productId)
        {
            var user = await _context.Users
                .Include(u => u.Favorites)
                .FirstOrDefaultAsync(u => u.Id == userId);

            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (user == null || product == null)
            {
                return;
            }

            user.Favorites.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsFavorited(string? userId, int productId)
        {
            var user = await _context.Users
                .Include(u => u.Favorites)
                .FirstOrDefaultAsync(u => u.Id == userId);

            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (user == null || product == null)
            {
                return false;
            }

            return user.Favorites.Contains(product);
        }
    }
}
