﻿using System;

namespace Watcher
{
    class Program
    {
        static void Main(string[] args)
        {
            const string incomingString = "incoming";
            using var directoryWatcher = new DirectoryWatcher(incomingString); 
            using var messageSender = new MessageSender<byte[]>();
            var watcher = new Watcher(messageSender, Stop, directoryWatcher, new FileManager());
            watcher.BeginWatch();
        }

        private static void Stop()
        {
            const string exitMessage = "quit";
            while (true)
            {
                Console.WriteLine($"Press '{exitMessage}' to quit the sample.");
                if (Console.ReadLine() == exitMessage)
                    break;
            }
        }
    }
}