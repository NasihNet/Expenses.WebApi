
using ExpensesCore.DTO;


namespace ExpensesCore
{
    public interface IExpensesServices
    {

        List<ExpenseDto> GetExpenses();

        ExpenseDto GetExpense(int id);

        ExpenseDto CreateExpense(Expenses.Db.Expense expense);

        void DeleteExpense(ExpenseDto expense);

        ExpenseDto EditExpense(ExpenseDto expense);


    }
}
