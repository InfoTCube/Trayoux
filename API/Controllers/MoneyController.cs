using API.DTOs;
using API.Interfaces;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace API.Controllers;

[Authorize]
public class MoneyController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public MoneyController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    [HttpGet("Expenses/{id}")]
    public async Task<ActionResult<IEnumerable<ExpenseDto>>> GetExpenseById(int id)
    {
        Expense expense = await _unitOfWork.MoneyRepository.GetExpenseByIdAsync(id);

        if(expense is null) return NotFound(id);

        if(User?.Identity?.Name == expense?.User?.UserName)
        {
            return Ok(_mapper.Map<ExpenseDto>(expense));
        }

        return Unauthorized();
    }

    [HttpGet("Gains/{id}")]
    public async Task<ActionResult<IEnumerable<ExpenseDto>>> GetGainById(int id)
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

    [HttpDelete("Expenses/{id}")]
    public async Task<ActionResult> DeleteExpense(int id)
    {
        return NoContent();
    }

    [HttpDelete("Gains/{id}")]
    public async Task<ActionResult> DeleteGain(int id)
    {
        return NoContent();
    }

    [HttpGet]
    public async Task<ActionResult<double>> GetBalance()
    {
        return NotFound();
    }
}
