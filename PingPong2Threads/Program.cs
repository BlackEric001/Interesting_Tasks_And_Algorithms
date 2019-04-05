using System;
using System.Threading;
using System.Threading.Tasks;

namespace PingPong2Threads
{
    class Program
    {
        private const int MAX = 10;
        private static volatile int counter = 0;
        private static object lk = new object();

        public static void Ping()
        {
            lock (lk)
            {
                while (counter < MAX)
                {
                    Console.WriteLine("ping");
                    Thread.Sleep(10);
                    counter++;
                    Monitor.Pulse(lk);
                    Monitor.Wait(lk);
                }
                Monitor.PulseAll(lk);
            }
        }

        public static void Pong()
        {
            lock (lk)
            {
                while (counter < MAX)
                {
                    Console.WriteLine("pong");
                    Thread.Sleep(10);
                    counter++;
                    Monitor.Pulse(lk);
                    Monitor.Wait(lk);
                }
                Monitor.PulseAll(lk);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Ping pong! In 2 Threads With Monitor");

            //Создаем и запускаем первый поток
            Thread t1 = new Thread(Ping);
            t1.Start();

            //Создаем и запускаем второй поток
            Thread t2 = new Thread(Pong);
            t2.Start();

            //Ждем завершения работы потоков что бы вывести надпись о конце работы приложения
            while(t1.IsAlive || t2.IsAlive)
            {
                ;
            }

            Console.WriteLine("The End!");
            Console.ReadLine();
        }
    }
}
