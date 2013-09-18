namespace PriorityQueueDemo
{
    using System;
    using PriorityQueue;

    public class Student : IComparable
    {
        public string Name { get; set; }

        public Student(string name)
        {
            this.Name = name;
        }

        public int CompareTo(object obj)
        {
            var student = obj as Student;

            if (student == null)
            {
                string exceptionMessage = string.Format("Cannot comapare {0} with {1}", this.GetType(), obj.GetType());
                throw new ArgumentException(exceptionMessage);
            }

            return this.Name.CompareTo(student.Name);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }

    public class PriorityQueueDemo
    {
        public static void Main()
        {
            var pesho = new Student("Pesho");
            var stamat = new Student("Stamat");
            var mimi = new Student("Mimi");
            var priorityQueue = new PriorityQueue<Student>();
            priorityQueue.Enqueue(pesho);
            priorityQueue.Enqueue(stamat);
            priorityQueue.Enqueue(mimi);
            Console.WriteLine(priorityQueue);
            Student first = priorityQueue.Dequeue();
            Console.WriteLine(first);
            Console.WriteLine(priorityQueue);
            Console.WriteLine(priorityQueue.Peek());
        }
    }
}