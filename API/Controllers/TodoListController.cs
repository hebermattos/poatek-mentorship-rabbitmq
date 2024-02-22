using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace rabbitmq_example.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoListController : ControllerBase
{
    private readonly TodoListContext _context;
    private readonly ReportService _reportService;

    public TodoListController(TodoListContext context, ReportService reportService)
    {
        _context = context;
        _reportService = reportService;
    }

    [HttpGet]
    public async Task<IEnumerable<TodoItem>> Get()
    {
        return await _context.TodoItens.AsNoTracking().ToListAsync();
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await _reportService.Remove(id);

        _context.TodoItens.Remove(new TodoItem { Id = id });

        await _context.SaveChangesAsync();
    }

    [HttpPost]
    public async Task Post(TodoItem model)
    {
        await _context.TodoItens.AddAsync(model);

        await _reportService.Update(model.Name);

        await _context.SaveChangesAsync();
    }
}