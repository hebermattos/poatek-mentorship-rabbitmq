using Microsoft.EntityFrameworkCore;

namespace rabbitmq_example;

public class TodoListContext : DbContext
{
    public DbSet<TodoItem> TodoItens { get; set; }
    public DbSet<TodoReport> TodoReports { get; set; }

    public TodoListContext(DbContextOptions<TodoListContext> options)
    : base(options)
    { }
}