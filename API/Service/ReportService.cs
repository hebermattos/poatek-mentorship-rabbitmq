using Microsoft.EntityFrameworkCore;

namespace rabbitmq_example;

public class ReportService
{
    private readonly TodoListContext _context;

    public ReportService(TodoListContext context)
    {
        _context = context;
    }

    public async Task Update(string name)
    {
        var todoReport = await _context.TodoReports.FirstOrDefaultAsync(x => x.Name.Equals(name));

        if (todoReport == null)
        {
            var newTodoReport = new TodoReport(name);

            await _context.TodoReports.AddAsync(newTodoReport);
        }
        else
        {
            todoReport.TaskCount++;
        }
    }

    public async Task Remove(int todoItemId)
    {
        var todoItem = await _context.TodoItens.AsNoTracking().FirstAsync(x => x.Id == todoItemId);

        var todoReport = await _context.TodoReports.FirstAsync(x => x.Name.Equals(todoItem.Name));

        todoReport.TaskCount--;
    }
}
