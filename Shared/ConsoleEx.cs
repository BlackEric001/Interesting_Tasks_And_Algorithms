using System;
using System.Linq;
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

        public static void printArray(string message, int[] array)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine(message);
            }
            Console.WriteLine(string.Join(", ", array.Select(x => x.ToString()).ToArray()));
        }
    }
}
