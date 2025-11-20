using Microsoft.AspNetCore.Mvc;
using CircularPortal.API.Data;
using CircularPortal.API.Models;

namespace CircularPortal.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context)
    {
        _context = context;
    }

    // PUT: /users
    [HttpPut]
    public async Task<IActionResult> UpdateUser(User user)
    {
        user.Id = 1; 
        
        _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }
    
    // GET: /users
    [HttpGet]
    public async Task<ActionResult<User>> GetUser()
    {
        return await _context.Users.FindAsync(1);
    }
}