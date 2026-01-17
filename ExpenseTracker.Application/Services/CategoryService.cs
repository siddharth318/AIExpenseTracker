using ExpenseTracker.Application.Interfaces.Repositories;
using ExpenseTracker.Application.Interfaces.Services;
using ExpenseTracker.Application.ViewModels.Categories;

namespace ExpenseTracker.Application.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<CategoryVm>> GetActiveCategoriesAsync()
    {
        var categories = await _categoryRepository.GetAllAsync();

        return categories
            .Where(c => c.IsActive)
            .Select(c => new CategoryVm
            {
                Id = c.Id,
                Name = c.Name
            });
    }
}
