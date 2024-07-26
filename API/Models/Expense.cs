using System.Data;

namespace API.Models;

public class Expense
{
    public int Id { get; set; }
    public double Amount { get; set; }
    public ExpenseCategory Category { get; set; }
    public DateOnly Date { get; set; }
    public AppUser? User { get; set; }
}