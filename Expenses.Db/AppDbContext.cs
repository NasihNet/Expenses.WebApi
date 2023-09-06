using Microsoft.EntityFrameworkCore;


namespace Expenses.Db
{

    /// <summary>
    /// install dependency entity framework - core - design - sqlserver tools
    /// </summary>

    public class AppDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=ExpensesDb;Trusted_Connection=True");
        }
    }
  
}
