using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace rabbitmq_example.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoListController : ControllerBase
{
    private readonly TodoListContext _context;

    public TodoListController(TodoListContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<TodoItem>> Get()
    {
        return await _context.TodoItens.AsNoTracking().ToListAsync();
    }

    [HttpPost]
    public async Task Post(TodoItem model)
    {
        await _context.TodoItens.AddAsync(model);

        await _context.SaveChangesAsync();
    }
}
