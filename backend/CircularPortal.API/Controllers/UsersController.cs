using Microsoft.AspNetCore.Mvc;
using CircularPortal.API.Models;
using CircularPortal.API.Services;

namespace CircularPortal.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    // PUT: /users
    [HttpPut]
    public async Task<IActionResult> UpdateUser(User user)
    {
        // Force ID to 1 for simulation (business logic remains here)
        user.Id = 1; 
        
        await _userService.UpdateUserAsync(user);
        return NoContent();
    }
    
    // GET: /users (To load the form initially)
    [HttpGet]
    public async Task<ActionResult<User>> GetUser()
    {
        var user = await _userService.GetUserAsync(1);
        if (user == null) return NotFound();
        return user;
    }
}