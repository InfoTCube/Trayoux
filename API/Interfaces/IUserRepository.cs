using API.Models;

namespace API.Interfaces;
public interface IUserRepository
{
    Task<AppUser> GetUserByUsernameAsync(string username);
}