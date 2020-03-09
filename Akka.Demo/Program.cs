using Akka.Actor;
using Akka.DI.Core;
using Akka.DI.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Akka.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IEmailNotification, EmailNotification>();
            serviceCollection.AddScoped<NotificationActor>();
            serviceCollection.AddScoped<TextNotificationActor>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            
            using var actorSystem = ActorSystem.Create("test-actor-system");
            actorSystem.UseServiceProvider(serviceProvider);
            
            var actor = actorSystem.ActorOf(actorSystem.DI().Props<NotificationActor>());

            Console.WriteLine("Enter message");
            while (true)
            {
                var message = Console.ReadLine();
                if (message == "q") break;
                actor.Tell(message);
            }
            Console.ReadLine();
            actorSystem.Stop(actor);
        }
    }
}
