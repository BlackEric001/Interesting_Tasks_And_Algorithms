using System;

namespace SinglyLinkedListReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Разворот односвязного списка в цикле и рекурсивно!");

            //1. Создаем и наполняем список 
            var list = new ListNode<int>();
            list.Item = 0;
            Append(list, new ListNode<int> { Item = 1 });
            Append(list, new ListNode<int> { Item = 2 });
            Append(list, new ListNode<int> { Item = 3 });

            /* Пример заполнения списка вручную
            list.Next = new ListNode<int>();
            list.Next.Item = 1;
            list.Next.Next = new ListNode<int>();
            list.Next.Next.Item = 2;*/

            //2. Выводим на печать
            Console.WriteLine("Исходный список");
            PrintList(list);

            //3. Разворачиваем циклом
            list = ReverseList(list);

            //4. Выводим на печать
            Console.WriteLine("После разворота");
            PrintList(list);

            //5. Разворачиваем обратно рекурсивно            
            list = ReverseRec(list, null);

            //6. Выводим на печать
            Console.WriteLine("После разворота обратно");
            PrintList(list);

            Console.WriteLine("The End");
            Console.ReadLine();
        }

        private static ListNode<T> ReverseRec<T>(ListNode<T> current, ListNode<T> prev)
        {
            if (current == null)
            {
                return prev;
            }

            ListNode<T> next = current.Next;
            current.Next = prev;
            return ReverseRec(next, current);
        }

        private static ListNode<T> ReverseList<T>(ListNode<T> list)
        {
            if (list == null || list.Next == null)
            {
                return list;
            }

            ListNode<T> n = null;
            while (list != null)
            {
                ListNode<T> tmp = list.Next;
                list.Next = n;
                n = list;
                list = tmp;
            }

            return n;
        }

        public static void Append<T>(ListNode<T> list, ListNode<T> newNode)
        {
            // если список пустой, то добавляемый элемент станет первым
            if (list == null)
                list = newNode;
            else
            {
                // Проходим по списку для нахождения последнего элемента. Цикл без тела
                ListNode<T> current;
                for (current = list; current.Next != null; current = current.Next) ;
                // add the item
                current.Next = newNode;
            }
        }

        private static void PrintList<T>(ListNode<T> list)
        {
            ListNode<T> node = list;
            do
            {
                Console.WriteLine(node.Item.ToString());
                node = node.Next;
            } while (node != null);
        }

    }

    internal class ListNode<T>
    {
        public T Item { get; set; }
        public ListNode<T> Next;
    }
}
