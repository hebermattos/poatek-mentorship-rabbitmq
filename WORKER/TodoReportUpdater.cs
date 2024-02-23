using MassTransit;

namespace rabbitmq_example;

public class TodoReportUpdater : IConsumer<TodoItemCreate>
{
    public Task Consume(ConsumeContext<TodoItemCreate> context)
    {
        throw new NotImplementedException();
    }
}
