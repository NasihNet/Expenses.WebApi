using Expenses.Db;


namespace ExpensesCore
{
    public class ExpensesServices : IExpensesServices
    {    
        private AppDbContext _context;
        public ExpensesServices(AppDbContext context) {

            _context = context;
        }

       
        public List<Expense> GetExpenses()
        {    
           return  _context.Expenses.OrderByDescending(x=> x.Id).ToList();
        }
        
        public Expense GetExpense(int id)
        {
            return _context.Expenses.First(x => x.Id == id);
        }

        public Expense CreateExpense(Expense expense)
        {
            _context.Expenses.Add(expense);
            _context.SaveChanges();
            return expense;

        
        }

        public void DeleteExpense(Expense expense)
        {
            _context.Expenses.Remove(expense);
            _context.SaveChanges();

        }

        public Expense EditExpense(Expense expense)
        {
            var dbExpense = _context.Expenses.First( x => x.Id == expense.Id);
                 
            dbExpense.Description = expense.Description;
            dbExpense.Amount = expense.Amount;
            _context.SaveChanges();

            return expense;
        }

    }
}