using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers
{
    class HashLogger : ILogger
    {
        private readonly string _name;
        private readonly ConcurrentDictionary<int, string> _logMessages;

        public HashLogger(string name) 
        { 
            _name = name;
            _logMessages = new ConcurrentDictionary<int, string>();
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var message = formatter(state, exception);
            switch (logLevel)
            {
                case LogLevel.Critical:
                    Console.ForegroundColor = ConsoleColor.Red; 
                    break;
                case LogLevel.Error: 
                    Console.ForegroundColor = ConsoleColor.DarkRed; 
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White; 
                    break;
            }

            Console.WriteLine("- LOGGER -");
            var messageToBeLogged = new StringBuilder();
            messageToBeLogged.Append($"[{logLevel}]");
            messageToBeLogged.AppendFormat(" [{0}]", _name);
            Console.WriteLine(messageToBeLogged);
            Console.WriteLine($"{formatter(state, exception)}");
            Console.WriteLine("- LOGGER -");
            Console.ResetColor();

            _logMessages[eventId.Id] = message;
        }

        public List<string> GetAllLogMessages()
        {
            return _logMessages.Values.ToList();
        }

        public void PrintMessageByEventId(int eventId)
        {
            if (_logMessages.TryGetValue(eventId, out var message))
            {
                Console.WriteLine($"Message for EventId {eventId}: {message}");
            }
            else
            {
                Console.WriteLine($"No message found for EventId {eventId}");
            }
        }

        public void DeleteMessageByEventId(int eventId)
        {
            _logMessages.TryRemove(eventId, out _);
            Console.WriteLine($"Message for EventId {eventId} deleted.");
        }

    }
}