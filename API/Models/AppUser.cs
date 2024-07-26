using Microsoft.AspNetCore.Identity;

namespace API.Models;

public class AppUser : IdentityUser
{   
    public double Balance { get; set; }
    public IEnumerable<Expense>? Expenses { get; set; }
    public IEnumerable<Gain>? Gains { get; set; }
}