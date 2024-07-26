using API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DataContext : IdentityDbContext<AppUser>
{
    public DataContext(DbContextOptions options) : base(options) {}

    protected DataContext() {}

    public DbSet<Expense> Expenses { get; set; }
    public DbSet<Gain> Gains { get; set; }
}