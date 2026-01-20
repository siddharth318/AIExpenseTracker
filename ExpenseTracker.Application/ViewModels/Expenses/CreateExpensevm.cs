using System.ComponentModel.DataAnnotations;
using ExpenseTracker.Application.ViewModels.Categories;
using ExpenseTracker.Domain.Entities;
using ExpenseTracker.Domain.Enums;

namespace ExpenseTracker.Application.ViewModels.Expenses;

public class CreateExpenseVm
{
    [Required]
    [Range(1, double.MaxValue)]
    public decimal Amount { get; set; }

    [Required]
    public DateTime ExpenseDate { get; set; }

    [Required]
    public Guid CategoryId { get; set; }

    [Required]
    public PaymentMode PaymentMode { get; set; }

    [MaxLength(200)]
    public string? Description { get; set; }

    public List<CategoryVm> Categories { get; set; } = new();
}

