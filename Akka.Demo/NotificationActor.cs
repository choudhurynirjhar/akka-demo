using Akka.Actor;
using System;

namespace Akka.Demo
{
    class NotificationActor : UntypedActor
    {
        private readonly IEmailNotification emailNotification;

        public NotificationActor(IEmailNotification emailNotification)
        {
            this.emailNotification = emailNotification;
        }

        protected override void OnReceive(object message)
        {
            Console.WriteLine($"Message received: {message}");
            emailNotification.Send(message?.ToString());
        }

        protected override void PreStart() => Console.WriteLine("Actor started");

        protected override void PostStop() => Console.WriteLine("Actor stopped");
    }
}
