using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class MoneyRepository : IMoneyRepository
{    
    private readonly DataContext _context;

    public MoneyRepository(DataContext context)
    {
        _context = context;
    }

    public async Task AddExpensesAsync(IEnumerable<Expense> expenses)
    {
        await _context.Expenses.AddRangeAsync(expenses);
    }

    public async Task AddGainsAsync(IEnumerable<Gain> gains)
    {
        await _context.Gains.AddRangeAsync(gains);
    }

    public void DeleteExpenseById(Expense expense)
    {
        _context.Expenses.Remove(expense);
    }

    public void DeleteGainById(Gain gain)
    {
        _context.Gains.Remove(gain);
    }

    public async Task<double> GetBalanceAsync(string username)
    {
        AppUser user = await _context.Users
            .Where(u => u.UserName == username)
            .FirstOrDefaultAsync();

        double gainSum = await _context.Gains
            .Include(gn => gn.User)
            .Where(gn => gn.User.UserName == username)
            .SumAsync(gn => gn.Amount);

        double expenseSum = await _context.Expenses
            .Include(ex => ex.User)
            .Where(ex => ex.User.UserName == username)
            .SumAsync(ex => ex.Amount);

        return user.Balance + gainSum - expenseSum;
    }

    public async Task<Expense> GetExpenseByIdAsync(int id)
    {
        return await _context.Expenses
            .Include(ex => ex.User)
            .Where(ex => ex.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Expense>> GetExpensesAsync(string username)
    {
        return await _context.Expenses
            .Include(ex => ex.User)
            .Where(ex => ex.User.UserName == username).ToListAsync();
    }

    public async Task<Gain> GetGainByIdAsync(int id)
    {
        return await _context.Gains
            .Include(gn => gn.User)
            .Where(gn => gn.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Gain>> GetGainsAsync(string username)
    {
        return await _context.Gains
            .Include(gn => gn.User)
            .Where(gn => gn.User.UserName == username).ToListAsync();
    }

    public async Task SetBalanceAsync(double amount, string username)
    {
        AppUser user = await _context.Users.Where(u => u.UserName == username).FirstOrDefaultAsync();

        user.Balance = amount;

        _context.Users.Update(user);
    }
}