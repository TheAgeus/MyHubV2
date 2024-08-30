using HubApi.Models;
using HubApi.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HubApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UsersController : ControllerBase
  {
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public UsersController(AppDbContext context, IConfiguration configuration)
    {
      _context = context;
      _configuration = configuration;
    }

    // GET: api/users
    [HttpGet(Name = "GetUsers")]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
      return await _context.Users.ToListAsync();
    }


    // GET a simple user by id
    [HttpGet("{id}", Name = "GetUser")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
      var user = await _context.Users.FindAsync(id);

      if (user == null)
      {
        return NotFound();
      }

      return user;
    }

    // POST a simple user
    [HttpPost]
    public async Task<ActionResult<User>> Post(User user)
    {
      _context.Add(user);
      await _context.SaveChangesAsync();
      
      return new CreatedAtActionResult("GetUser", "UsersController",  new { id = user.Id }, user);
    }

  }
}