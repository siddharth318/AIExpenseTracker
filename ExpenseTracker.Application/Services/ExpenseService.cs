using ExpenseTracker.Application.DTOs;
using ExpenseTracker.Application.Interfaces.Repositories;
using ExpenseTracker.Application.Interfaces.Services;
using ExpenseTracker.Application.ViewModels.Expenses;
using ExpenseTracker.Domain.Entities;

namespace ExpenseTracker.Application.Services;

public class ExpenseService : IExpenseService
{
    private readonly IExpenseRepository _expenseRepository;
    private readonly ICategoryRepository _categoryRepository;

    public ExpenseService(IExpenseRepository expenseRepository, ICategoryRepository categoryRepository)
    {
        _expenseRepository = expenseRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task CreateAsync(CreateExpenseVm vm, Guid userId)
    {
        // Business rule: category must exist & be active
        var category = await _categoryRepository.GetByIdAsync(vm.CategoryId);

        if (category is null || !category.IsActive)
            throw new InvalidOperationException("Invalid or inactive category.");

        var expense = new Expense
        {
            Amount = vm.Amount,
            ExpenseDate = vm.ExpenseDate,
            CategoryId = vm.CategoryId,
            PaymentMode = vm.PaymentMode,
            Description = vm.Description,
            CreatedOn = DateTime.UtcNow
        };

        await _expenseRepository.AddAsync(expense);
        await _expenseRepository.SaveChangesAsync();
    }

    public async Task<IEnumerable<ExpenseDto>> GetExpensesForUserAsync(Guid userId)
    {
        // 1. Fetch domain entities from repository
        var expenses = await _expenseRepository.GetByUserAsync(userId);

        // 2. Map domain entities to DTOs
        var expenseDtos = expenses.Select(e => new ExpenseDto
        {
            Id = e.Id,
            Amount = e.Amount,
            ExpenseDate = e.ExpenseDate,
            CategoryName = e.Category != null
                ? e.Category.Name
                : "Unknown",
            PaymentMode = e.PaymentMode.ToString(),
            Description = e.Description
        });

        // 3. Return DTOs to controller / UI
        return expenseDtos;
    }
}
