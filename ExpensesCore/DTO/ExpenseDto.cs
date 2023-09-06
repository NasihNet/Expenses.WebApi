using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesCore.DTO
{
    public class ExpenseDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public double Amount { get; set; }

        public static explicit operator ExpenseDto(Expenses.Db.Expense e) => new ExpenseDto
        {

            Id = e.Id,
            Description = e.Description,
            Amount = e.Amount
        };
    }
}
