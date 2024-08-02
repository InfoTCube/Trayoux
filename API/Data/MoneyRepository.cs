using API.Data.Migrations;
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

    public void DeleteExpenseByIdAsync(Expense expense)
    {
        _context.Expenses.Remove(expense);
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
}