using API.Models;

namespace API.Interfaces;

public interface IMoneyRepository
{
    Task<Expense> GetExpenseByIdAsync(int id);
    Task<IEnumerable<Expense>> GetExpensesAsync(string username);
    Task AddExpensesAsync(IEnumerable<Expense> expenses);
    void DeleteExpenseByIdAsync(Expense expense);
}