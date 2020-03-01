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
            serviceCollection.AddSingleton<IEmailNotification, EmailNotification>();
            serviceCollection.AddSingleton<NotificationActor>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            
            using var actorSystem = ActorSystem.Create("test-actor-system");
            actorSystem.UseServiceProvider(serviceProvider);
            
            var actor = actorSystem.ActorOf(actorSystem.DI().Props<NotificationActor>());
            actor.Tell("Hello there!");
            Console.ReadLine();
            actorSystem.Stop(actor);
        }
    }
}
