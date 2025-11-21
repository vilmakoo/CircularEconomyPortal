namespace CircularPortal.API.Services;

using CircularPortal.API.Data;
using CircularPortal.API.Models;
using Microsoft.EntityFrameworkCore;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetUserAsync(int id)
    {
        // Fetch the user by ID
        return await _context.Users.FindAsync(id);
    }

    public async Task UpdateUserAsync(User user)
    {
        // Mark the entity as modified and save changes
        _context.Entry(user).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}