using API.Models;

namespace API.DTOs;

public class GainDto
{
    public double Amount { get; set; }
    public GainCategory Category { get; set; }
    public DateOnly Date { get; set; }
}