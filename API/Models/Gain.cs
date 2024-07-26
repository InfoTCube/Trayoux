namespace API.Models;

public class Gain
{
    public int Id { get; set; }
    public double Amount { get; set; }
    public GainCategory Category { get; set; }
    public DateOnly Date { get; set; }
    public AppUser? User { get; set; }
}
