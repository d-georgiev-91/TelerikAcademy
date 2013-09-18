namespace StackDemo
{
    using System;
    using Stack;

    class StackDemo
    {
        static void Main()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(15);
            Console.WriteLine("Current top is {0}", stack.Top);
            stack.Push(141);
            Console.WriteLine("Current top is {0}", stack.Top);
            stack.Push(14121);
            Console.WriteLine("Current top is {0}", stack.Top);
            stack.Push(1421);
            Console.WriteLine("Current top is {0}", stack.Top);
            var popedItem = stack.Pop();
            Console.WriteLine("Poped {0}, current top is {1}", popedItem, stack.Top);
            var peekedItem = stack.Peek();
            Console.WriteLine("Peeked {0}, current top is {1}", peekedItem, stack.Top);
        }
    }
}