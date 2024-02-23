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
            todoReport.TaskUnfinished++;
        }  

        await _context.SaveChangesAsync();
    }

    public async Task Update(string name, bool completed)
    {
        var todoReport = await _context.TodoReports.FirstAsync(x => x.Name.Equals(name));

        if (completed)
        {
            todoReport.Taskfinished++;
            todoReport.TaskUnfinished--;
        }
        else
        {
            todoReport.Taskfinished--;
            todoReport.TaskUnfinished++;
        }
    }

    public async Task Update(int todoItemId)
    {
        var todoItem = await _context.TodoItens.AsNoTracking().FirstAsync(x => x.Id == todoItemId);

        var todoReport = await _context.TodoReports.FirstAsync(x => x.Name.Equals(todoItem.Name));

        todoReport.TaskCount--;

        if (todoItem.Completed)
            todoReport.Taskfinished--;
        else
            todoReport.TaskUnfinished--;
    }


}
