using System;

namespace Kitchen
{
    class Potato : Vegetable, IPeelable
    {
        public void Peel()
        {
            Console.WriteLine("Peeling the patato!");
        }

        public override string ToString()
        {
            return "potato";
        }
    }
}