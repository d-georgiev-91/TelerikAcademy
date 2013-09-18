using System;

namespace CookingPotatoes
{
    class CookingPotatoes
    {
        static void Main()
        {
            Potato potato = new Potato();

            if (potato != null)
            {
                if (potato.HasBeenPeeled && !potato.IsRotten)
                {
                    Cook(potato);
                }
            }
        }

        private static void Cook(Potato potato)
        {
            string whatIsCooking = potato.GetType().ToString().Replace("CookingPotatoes.", String.Empty).ToLower();
            Console.WriteLine("Cooking {0}...", whatIsCooking);
        }
    }
}
