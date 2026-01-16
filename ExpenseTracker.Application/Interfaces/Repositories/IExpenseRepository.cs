using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Application.Interfaces.Repositories;

public interface IExpenseRepository
{
    Task AddAsync(Expense expense);
    Task<Expense?> GetByIdAsync(Guid id);
    Task<IEnumerable<Expense>> GetByUserAsync(Guid userId);
    Task SaveChangesAsync();
}