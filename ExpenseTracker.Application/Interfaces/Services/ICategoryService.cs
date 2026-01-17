using ExpenseTracker.Application.ViewModels.Categories;

namespace ExpenseTracker.Application.Interfaces.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryVm>> GetActiveCategoriesAsync();
}
