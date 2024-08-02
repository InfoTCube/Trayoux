using API.Models;

namespace API.DTOs;

public class NewGainDto
{
    public double Amount { get; set; }
    public GainCategory Category { get; set; }
}