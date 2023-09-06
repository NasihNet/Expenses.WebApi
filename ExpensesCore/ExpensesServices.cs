
using ExpensesCore.DTO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;

namespace ExpensesCore
{
    public class ExpensesServices : IExpensesServices
    {    
        private Expenses.Db.AppDbContext _context;
        private readonly Expenses.Db.User _user;
        public ExpensesServices(Expenses.Db.AppDbContext context, IHttpContextAccessor httpContextAccessor) {

            _context = context;
            _user = _context.Users
                .First(x => x.Username == httpContextAccessor.HttpContext.User.Identity.Name);
        }


        public ExpenseDto GetExpense(int id) =>
           _context.Expenses
               .Where(e => e.User.Id == _user.Id && e.Id == id)
               .Select(e => (ExpenseDto)e)
               .First();


        public List<ExpenseDto> GetExpenses() =>
             _context.Expenses
                 .Where(e => e.User.Id == _user.Id)
                 .Select(e => (ExpenseDto)e)
                 .ToList();



        public ExpenseDto CreateExpense(Expenses.Db.Expense expense)
        {
            expense.User = _user;
            _context.Expenses.Add(expense);
            _context.SaveChanges();
            return (ExpenseDto)expense;

        
        }

        public void DeleteExpense(ExpenseDto expense)
        {    
            var dbExpense = _context.Expenses.First(x => x.Id == expense.Id && x.User.Id == _user.Id);
            _context.Expenses.Remove(dbExpense);
            _context.SaveChanges();

        }

        public ExpenseDto EditExpense(ExpenseDto expense)
        {
            var dbExpense = _context.Expenses.First(x => x.Id == expense.Id && x.User.Id == _user.Id);

            dbExpense.Description = expense.Description;
            dbExpense.Amount = expense.Amount;
            _context.SaveChanges();

            return expense;
        }

    }
}