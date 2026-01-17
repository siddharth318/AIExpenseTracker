namespace ExpenseTracker.Application.DTOs;

public class ExpenseDto
{
    public Guid Id { get; set; }

    public decimal Amount { get; set; }

    public DateTime ExpenseDate { get; set; }

    public string CategoryName { get; set; } = string.Empty;

    public string PaymentMode { get; set; } = string.Empty;

    public string? Description { get; set; }
}
