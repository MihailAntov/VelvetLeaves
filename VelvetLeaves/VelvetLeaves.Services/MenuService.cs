﻿

using Microsoft.EntityFrameworkCore;
using VelvetLeaves.Data;
using VelvetLeaves.Services.Contracts;
using VelvetLeaves.ViewModels.Menu;


namespace VelvetLeaves.Services
{
    public class MenuService : IMenuService
    {
        private readonly VelvetLeavesDbContext context;
        public MenuService(VelvetLeavesDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<CategoryMenuViewModel>> GetMenuCategoriesAsync()
        {
            var result = await context.Categories
                .Select(c => new CategoryMenuViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    ImageUrl = c.ImageUrl,
                    Subcategories = c.Subcategories.Select(sc => new SubcategoryMenuViewModel()
                    {
                        Id = sc.Id,
                        Name = sc.Name
                    }).ToArray()
                }).ToArrayAsync();

            return result;
        }
    }
}
