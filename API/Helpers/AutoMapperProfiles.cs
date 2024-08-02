using API.DTOs;
using API.Models;
using AutoMapper;

namespace API.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<Expense, ExpenseDto>();
        CreateMap<NewExpenseDto, Expense>();
        CreateMap<Gain, GainDto>();
        CreateMap<NewGainDto, Gain>();
    }
}
