using API.DTOs;
using API.Interfaces;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        Gain gain = await _unitOfWork.MoneyRepository.GetGainByIdAsync(id);

        if(gain is null) return NotFound(id);

        if(User?.Identity?.Name == gain?.User?.UserName)
        {
            return Ok(_mapper.Map<GainDto>(gain));
        }

        return Unauthorized();
    }

    [HttpGet("Expenses")]
    public async Task<ActionResult<IEnumerable<ExpenseDto>>> GetExpenses()
    {
        string username = User.Identity.Name;
        IEnumerable<Expense> expenses = await _unitOfWork.MoneyRepository.GetExpensesAsync(username);

        return Ok(_mapper.Map<IEnumerable<ExpenseDto>>(expenses));
    }

    [HttpGet("Gains")]
    public async Task<ActionResult<IEnumerable<ExpenseDto>>> GetGains()
    {
        string username = User.Identity.Name;
        IEnumerable<Gain> gains = await _unitOfWork.MoneyRepository.GetGainsAsync(username);

        return Ok(_mapper.Map<IEnumerable<GainDto>>(gains));
    }

    [HttpPost("Expenses")]
    public async Task<ActionResult<IEnumerable<NewExpenseDto>>> AddExpenses(IEnumerable<NewExpenseDto> newExpenses)
    {
        if(newExpenses.Any() == false) return BadRequest("There is nothing to create.");

        IEnumerable<Expense> expenses = _mapper.Map<IEnumerable<Expense>>(newExpenses); 

        string username = User.Identity.Name;
        AppUser user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(username);
        foreach(Expense ex in expenses)
        {
            ex.Date = DateOnly.FromDateTime(DateTime.Now);
            ex.User = user;
        }

        await _unitOfWork.MoneyRepository.AddExpensesAsync(expenses);
        await _unitOfWork.Complete();

        return Created();
    }

    [HttpPost("Gains")]
    public async Task<ActionResult<IEnumerable<NewGainDto>>> AddGains(IEnumerable<NewGainDto> newGains)
    {
        if(newGains.Any() == false) return BadRequest("There is nothing to create.");

        IEnumerable<Gain> gains = _mapper.Map<IEnumerable<Gain>>(newGains); 

        string username = User.Identity.Name;
        AppUser user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(username);
        foreach(Gain gn in gains)
        {
            gn.Date = DateOnly.FromDateTime(DateTime.Now);
            gn.User = user;
        }

        await _unitOfWork.MoneyRepository.AddGainsAsync(gains);
        await _unitOfWork.Complete();

        return Created();
    }

    [HttpDelete("Expenses/{id}")]
    public async Task<ActionResult> DeleteExpense(int id)
    {
        Expense expense = await _unitOfWork.MoneyRepository.GetExpenseByIdAsync(id);
        string username = User.Identity.Name;

        if(expense?.User?.UserName != username) return Unauthorized();

        _unitOfWork.MoneyRepository.DeleteExpenseById(expense);

        if (await _unitOfWork.Complete()) return Ok();

        return BadRequest("Problem deleting the expense.");
    }

    [HttpDelete("Gains/{id}")]
    public async Task<ActionResult> DeleteGain(int id)
    {
        Gain gain = await _unitOfWork.MoneyRepository.GetGainByIdAsync(id);
        string username = User.Identity.Name;

        if(gain?.User?.UserName != username) return Unauthorized();

        _unitOfWork.MoneyRepository.DeleteGainById(gain);

        if (await _unitOfWork.Complete()) return Ok();

        return BadRequest("Problem deleting the gain.");
    }

    [HttpGet]
    public async Task<ActionResult<double>> GetBalance()
    {
        string username = User.Identity.Name;
        double balance = await _unitOfWork.MoneyRepository.GetBalanceAsync(username);
        return Ok(balance);
    }

    [HttpPost]
    public async Task<ActionResult> SetBalance(double amount)
    {
        string username = User.Identity.Name;
        await _unitOfWork.MoneyRepository.SetBalanceAsync(amount, username);
        await _unitOfWork.Complete();
        return Created();
    }
}
