using System;

namespace Akka.Demo
{
    public class EmailNotification : IEmailNotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending email with message: {message}");
        }
    }
}
