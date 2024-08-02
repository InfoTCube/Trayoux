using API.Models;

namespace API.DTOs;

public class NewExpenseDto
{
    public double Amount { get; set; }
    public ExpenseCategory Category { get; set; }
}