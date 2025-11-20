using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CircularPortal.API.Data;
using CircularPortal.API.Models;

namespace CircularPortal.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WasteBinsController : ControllerBase
{
    private readonly AppDbContext _context;

    public WasteBinsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: /wastebins
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WasteBin>>> GetWasteBins()
    {
        return await _context.WasteBins.Where(b => b.UserId == 1).ToListAsync();
    }

    // GET: /wastebins/5
    [HttpGet("{id}")]
    public async Task<ActionResult<WasteBin>> GetWasteBin(int id)
    {
        var bin = await _context.WasteBins.FindAsync(id);
        if (bin == null) return NotFound();
        return bin;
    }
}