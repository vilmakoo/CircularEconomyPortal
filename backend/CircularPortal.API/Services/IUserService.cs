namespace CircularPortal.API.Services;

using CircularPortal.API.Models;

public interface IUserService
{
    Task<User?> GetUserAsync(int id);
    Task UpdateUserAsync(User user);
}