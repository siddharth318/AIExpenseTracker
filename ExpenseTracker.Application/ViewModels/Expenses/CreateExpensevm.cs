using ExpenseTracker.Domain.Enums;

namespace ExpenseTracker.Application.ViewModels.Expenses;

public class CreateExpenseVm
{
    public decimal Amount { get; set; }
    public DateTime ExpenseDate { get; set; }
    public Guid CategoryId { get; set; }
    public PaymentMode PaymentMode { get; set; }
    public string? Description { get; set; }
}
