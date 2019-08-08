using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shared
{
    public static class ConsoleEx
    {
        public static void WriteLine(string message)
        {
            Console.WriteLine($"[Time: {DateTime.Now.ToShortTimeString()}, Thread {Thread.CurrentThread.ManagedThreadId}]: {message} ");
        }

        public static async void WriteLineAsync(string message)
        {
            await Task.Run(() => Console.WriteLine($"[Time: {DateTime.Now.ToShortTimeString()}, Thread {Thread.CurrentThread.ManagedThreadId}]: {message} "));
        }
    }
}
