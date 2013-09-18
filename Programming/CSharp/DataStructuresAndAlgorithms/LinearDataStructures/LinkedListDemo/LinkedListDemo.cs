namespace LinkedListDemo
{
    using System;
    using LinkedList;
    
    class LinkedListDemo
    {
        static void Main()
        {
            var linkedList = new LinkedList<int>();
            linkedList.AddFirst(5);
            Console.WriteLine("First value is {0}", linkedList.FirstElement);
            linkedList.AddFirst(51);
            Console.WriteLine("First value is {0}", linkedList.FirstElement);
            linkedList.AddLast(42);
            Console.WriteLine("Last value is {0}", linkedList.LastElement);
            linkedList.AddLast(0);
            Console.WriteLine("Last value is {0}", linkedList.LastElement);
            linkedList.AddBefore(linkedList.FirstElement, 5);
            Console.WriteLine("First value is {0}, Next value is {1}", linkedList.FirstElement, linkedList.FirstElement.Next);
            // Мързи ме да дописвам, но ако пуснеш тестовете се надявам, че си личи, че работи :D
        }
    }
}