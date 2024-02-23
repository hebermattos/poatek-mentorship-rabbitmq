using MassTransit;
using Microsoft.EntityFrameworkCore;
using rabbitmq_example;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        IConfiguration configuration = hostContext.Configuration;

        services.AddScoped<ReportService>();

        services.AddDbContext<TodoListContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddMassTransit(x =>
        {
            x.AddConsumer<TodoReportUpdater>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(configuration["RabbitMq:host"], "/", h =>
                {
                    h.Username(configuration["RabbitMq:user"]);
                    h.Password(configuration["RabbitMq:password"]);
                });

                cfg.ConfigureEndpoints(context);
            });
        });
    })
    .Build();

await host.RunAsync();
