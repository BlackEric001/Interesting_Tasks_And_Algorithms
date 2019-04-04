using System;
using System.Numerics;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа выполняет расчет чисел Фибоначчи в цикле и рекурсивно.");
            Console.WriteLine("При значениях свыше 40 рекурсивный расчет сильно тормозит на core i5-2500.");
            Console.WriteLine(String.Format("При значениях свыше 40 type int переполняется. sizeof(int) = {0}", sizeof(int)));
            Console.WriteLine(String.Format("При значениях свыше 93 type ulong переполняется. sizeof(ulong) = {0}", sizeof(long)));
            Console.WriteLine("Для вычисления используется BigInteger. Для номера 2222 вроде бы не переполнилось...");
            Console.WriteLine();
            Console.WriteLine("Введите номер числа Фибоначчи:");

            int fibNumber = 0;

            if (Int32.TryParse(Console.ReadLine(), out fibNumber))
            {
                Console.WriteLine("Получение числа Фибоначчи циклом:");
                BigInteger prev = 0;
                for (int i = 0; i <= fibNumber; i++)
                {
                    BigInteger value = getFibonacciValueLoop(i);
                    if (value >= prev)
                        Console.WriteLine(String.Format("Число Фибоначчи {0} = {1}", i, value));
                    else
                    {
                        Console.WriteLine("Переполнение ulong! Прекращение расчета в цикле!");
                        break;
                    }
                    prev = value;
                }

                Console.WriteLine("");

                Console.WriteLine("Получение числа Фибоначчи рекурсивно:");
                for (int i = 0; i <= fibNumber; i++)
                    Console.WriteLine(String.Format("Число Фибоначчи {0} = {1}", i, getFibonacciValueRec(i)));

                Console.WriteLine("");
            }
            else
                Console.WriteLine("Номер числа Фибоначчи должен быть целым и >= 0");

            Console.WriteLine("Нажмите любую клавишу для выхода");
            Console.ReadLine();
        }

        static BigInteger getFibonacciValueLoop(int fibNumber)
        {
            BigInteger f0 = 0;
            BigInteger f1 = 1;
            BigInteger res = 0;

            if (fibNumber == 0)
                res = f0;
            else
                if (fibNumber == 1)
                res = f1;
            else
            {
                for (int i = 2; i <= fibNumber; i++)
                {
                    res = f0 + f1;
                    f0 = f1;
                    f1 = res;
                }
            }

            return res;
        }

        static long getFibonacciValueRec(int fibNumber)
        {
            return fibNumber > 1 ? getFibonacciValueRec(fibNumber - 1) + getFibonacciValueRec(fibNumber - 2) : fibNumber;
        }

    }
}
