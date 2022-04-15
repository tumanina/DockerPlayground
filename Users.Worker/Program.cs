using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Users.Data;
using Users.Data.Configuration;
using Users.Data.Context;
using Users.Data.Repositories;
using Users.Worker.Configuration;

namespace Users.Worker
{
    class Program
    {
        public static IConfigurationRoot _configuration;

        static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using IServiceScope serviceScope = host.Services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;
            var repository = provider.GetRequiredService<IUsersRepository>();

            var settings = provider.GetRequiredService<IOptions<MessageSenderSettings>>();

            var channel = CreateChannel(settings.Value);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var message = Encoding.UTF8.GetString(ea.Body);
                repository.AddUserAsync(JsonSerializer.Deserialize<User>(message));
            };
            channel.BasicConsume(queue: settings.Value.Queue, autoAck: true, consumer: consumer);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();

            await host.RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
           .ConfigureServices((hostBuilderContext, serviceCollection) =>
                {
                    _configuration = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                        .AddJsonFile("appsettings.json", false)
                        .Build();

                    serviceCollection.AddSingleton<IConfiguration>(_configuration);

                    serviceCollection.Configure<MessageSenderSettings>(_configuration.GetSection(nameof(MessageSenderSettings)));
                    serviceCollection.Configure<DatabaseSettings>(_configuration.GetSection(nameof(DatabaseSettings)));

                    serviceCollection.AddScoped<IUsersContext, UsersContext>();
                    serviceCollection.AddScoped<IUsersRepository, UsersRepository>();
                });

        private static IModel CreateChannel(MessageSenderSettings settings)
        {
            ConnectionFactory factory = new ConnectionFactory() { HostName = settings.HostName, Port = settings.Port };
            factory.UserName = settings.UserName;
            factory.Password = settings.Password;
            IConnection conn = factory.CreateConnection();
            IModel channel = conn.CreateModel();
            channel.QueueDeclare(queue: settings.Queue,
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            return channel;
        }
    }
}
