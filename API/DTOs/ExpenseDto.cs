using API.Models;

namespace API.DTOs;

public class ExpenseDto
{
    public double Amount { get; set; }
    public ExpenseCategory Category { get; set; }
    public DateOnly Date { get; set; }
}