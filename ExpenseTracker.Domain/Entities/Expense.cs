using ExpenseTracker.Domain.Base;
using ExpenseTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Domain.Entities
{
    public class Expense : BaseEntity
    {
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }

        public Guid CategoryId { get; set; }     // FK
        public Category? Category { get; set; }  // Navigation property

        public PaymentMode PaymentMode { get; set; }
        public string? Description { get; set; }
    }
}
