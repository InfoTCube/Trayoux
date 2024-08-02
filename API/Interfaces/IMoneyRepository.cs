using API.Models;

namespace API.Interfaces;

public interface IMoneyRepository
{
    Task<Expense> GetExpenseByIdAsync(int id);
    Task<IEnumerable<Expense>> GetExpensesAsync(string username);
    Task AddExpensesAsync(IEnumerable<Expense> expenses);
    void DeleteExpenseByIdAsync(Expense expense);
    Task<Gain> GetGainByIdAsync(int id);
    Task<IEnumerable<Gain>> GetGainsAsync(string username);
    Task AddGainsAsync(IEnumerable<Gain> gains);
    void DeleteGainByIdAsync(Gain gain);
}