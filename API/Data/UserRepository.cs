using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;
public class UserRepository : IUserRepository
{
    private readonly DataContext _context;
    public UserRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<AppUser> GetUserByUsernameAsync(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
    }
}