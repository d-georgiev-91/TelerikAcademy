using System;

namespace Kitchen
{
    class Carrot : Vegetable, IPeelable
    {
        public void Peel()
        {
            Console.WriteLine("Peeling the carrot!");
        }

        public override string ToString()
        {
            return "carrot";
        }
    }
}
