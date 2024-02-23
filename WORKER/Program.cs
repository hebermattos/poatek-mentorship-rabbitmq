using MassTransit;
using rabbitmq_example;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddMassTransit(x =>
        {
            IConfiguration configuration = hostContext.Configuration;

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
