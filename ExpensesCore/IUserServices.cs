using Expenses.Db;
using ExpensesCore.DTO;


namespace ExpensesCore
{
    public interface IUserServices 
    {
       Task<AuthenticatedUser> SignUp(User user);

        Task<AuthenticatedUser> SignIn(User user);
    }
}
