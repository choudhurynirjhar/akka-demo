using Akka.Actor;
using System;

namespace Akka.Demo
{
    class TextNotificationActor : UntypedActor
    {
        protected override void PreStart() =>
            Console.WriteLine("TextNotification child stared!");

        protected override void PostStop() =>
            Console.WriteLine("TextNotification child stopped!");

        protected override void OnReceive(object message)
        {
            if (message.ToString() == "n")
                throw new NullReferenceException();
            if (message.ToString() == "e")
                throw new ArgumentException();
            if (string.IsNullOrEmpty(message.ToString()))
                throw new Exception();

            Console.WriteLine($"Sending text message {message}");
        }
    }
}
