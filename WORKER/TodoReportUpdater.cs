using MassTransit;

namespace rabbitmq_example;

public class TodoReportUpdater : IConsumer<TodoItemCreate>
{
    private ReportService _reportService;

    public TodoReportUpdater(ReportService reportService)
    {
        _reportService = reportService;
    }

    public async Task Consume(ConsumeContext<TodoItemCreate> context)
    {
        await _reportService.Update(context.Message.Name);
    }
}
