using ExpenseTracker.Application.Interfaces.Services;
using ExpenseTracker.Application.ViewModels.Categories;
using ExpenseTracker.Application.ViewModels.Expenses;
using ExpenseTracker.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class ExpensesController : Controller
{
    private readonly IExpenseService _expenseService;
    private readonly ICategoryService _categoryService;

    public ExpensesController(
        IExpenseService expenseService,
        ICategoryService categoryService)
    {
        _expenseService = expenseService;
        _categoryService = categoryService;
    }

    // LIST
    public async Task<IActionResult> Index()
    {
        var expenses = await _expenseService.GetExpensesForUserAsync(Guid.Empty);
        return View(expenses);
    }

    // CREATE (GET) : This is for the 1st time when the UI loads the Create Expense page
    public async Task<IActionResult> Create()
    {
        var categories = await _categoryService.GetActiveCategoriesAsync();

        var vm = new CreateExpenseVm
        {
            Categories = categories.Select(c => new CategoryVm
            {
                Id = c.Id,
                Name = c.Name
            }).ToList()
        };

        return View(vm);
    }

    // CREATE (POST)
    //This is for when the user fills the form and clicks on Submit button
    [HttpPost]
    public async Task<IActionResult> Create(CreateExpenseVm vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        await _expenseService.CreateAsync(vm, Guid.Empty);
        return RedirectToAction(nameof(Index));
    }
}
