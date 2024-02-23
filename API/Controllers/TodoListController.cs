using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace rabbitmq_example.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoListController : ControllerBase
{
    private readonly TodoListContext _context;
    private readonly ReportService _reportService;
    private readonly IBusControl _busControl;

    public TodoListController(TodoListContext context, ReportService reportService, IBusControl busControl)
    {
        _context = context;
        _reportService = reportService;
        _busControl = busControl;
    }

    [HttpGet]
    public async Task<IEnumerable<TodoItem>> Get()
    {
        return await _context.TodoItens.AsNoTracking().ToListAsync();
    }

    [HttpPut("{id}")]
    public async Task<TodoItem> Put(int id, TodoItemUpdate model)
    {
        var todoItem = await _context.TodoItens.FirstAsync(x => x.Id == id);

        todoItem.Completed = model.Completed;

        await _reportService.Update(todoItem.Name, model.Completed);

        await _context.SaveChangesAsync();

        return todoItem;
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        _context.TodoItens.Remove(new TodoItem(id));

        await _reportService.Update(id);

        await _context.SaveChangesAsync();
    }

    [HttpPost]
    public async Task<TodoItem> Post(TodoItemCreate model)
    {
        var newTodoItem = new TodoItem(model.Name, model.Task);

        await _context.TodoItens.AddAsync(newTodoItem);

        await _busControl.Publish(model);

        //await _reportService.Update(model.Name);

        await _context.SaveChangesAsync();

        return newTodoItem;
    }
}