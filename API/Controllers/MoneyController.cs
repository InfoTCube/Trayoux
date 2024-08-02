using API.Data;
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
        if(newExpenses.Any() == false) return BadRequest("There is nothing to create.");

        IEnumerable<Expense> expenses = _mapper.Map<IEnumerable<Expense>>(newExpenses); 

        string username = User.Identity.Name;
        AppUser user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(username);
        foreach(Expense e in expenses)
        {
            e.Date = DateOnly.FromDateTime(DateTime.Now);
            e.User = user;
        }

        await _unitOfWork.MoneyRepository.AddExpensesAsync(expenses);
        await _unitOfWork.Complete();

        return Created();
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
