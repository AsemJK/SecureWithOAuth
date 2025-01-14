using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureWithOAuth.Data;
using SecureWithOAuth.Models;

namespace SecureWithOAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public TasksController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<List<ToDo>> ListTodos()
        {
            return dbContext.ToDos.ToList();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ToDo todo)
        {
            dbContext.ToDos.Add(todo);
            await dbContext.SaveChangesAsync();
            return Ok(todo);
        }
    }
}
