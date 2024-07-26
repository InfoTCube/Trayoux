using API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
public class MoneyController : BaseApiController
{
    public MoneyController()
    {
    }

    [HttpGet("Expenses/{Id}")]
    public async Task<ActionResult<IEnumerable<ExpenseDto>>> GetExpenseById(int Id)
    {
        return NotFound();
    }

    [HttpGet("Gains/{Id}")]
    public async Task<ActionResult<IEnumerable<ExpenseDto>>> GetGainById(int Id)
    {
        return NotFound();
    }

    [HttpGet("Expenses")]
    public async Task<ActionResult<IEnumerable<ExpenseDto>>> GetExpenses()
    {
        return NotFound();
    }

    [HttpGet("Gains")]
    public async Task<ActionResult<IEnumerable<ExpenseDto>>> GetGains()
    {
        return NotFound();
    }

    [HttpPost("Expenses")]
    public async Task<ActionResult<IEnumerable<NewExpenseDto>>> AddExpenses(IEnumerable<NewExpenseDto> newExpenses)
    {
        return NotFound();
    }

    [HttpPost("Gains")]
    public async Task<ActionResult<IEnumerable<NewGainDto>>> AddGains(IEnumerable<NewGainDto> newExpenses)
    {
        return NotFound();
    }

    [HttpDelete("Expenses/{Id}")]
    public async Task<ActionResult> DeleteExpense(int Id)
    {
        return NoContent();
    }

    [HttpDelete("Gains/{Id}")]
    public async Task<ActionResult> DeleteGain(int Id)
    {
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<double>> GetBalance()
    {
        return NotFound();
    }
}
