using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Application.ViewModels.Expenses;

namespace ExpenseTracker.Application.Interfaces.Services;

public interface IExpenseService
{
    Task CreateAsync(CreateExpenseVm vm, Guid userId);
    Task<IEnumerable<ExpenseDto>> GetExpensesForUserAsync(Guid userId);

}
