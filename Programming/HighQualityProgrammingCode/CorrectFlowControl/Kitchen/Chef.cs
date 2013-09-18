using System;

namespace Kitchen
{
    class Chef
    {
        public void Cook()
        {
            Bowl bowl;
            bowl = GetBowl();

            Potato potato = GetPotato();
            potato.Peel();
            this.Cut(potato);
            bowl.Add(potato);

            Carrot carrot = GetCarrot();
            carrot.Peel();
            this.Cut(carrot);
            bowl.Add(carrot);
        }

        private Bowl GetBowl()
        {
            Bowl bowl = new Bowl();
            return bowl;
        }

        private Potato GetPotato()
        {
            Potato potato = new Potato();
            return potato;
        }

        private Carrot GetCarrot()
        {
            Carrot carrot = new Carrot();
            return carrot;
        }


        private void Cut(Vegetable vegetable)
        {
            Console.WriteLine("Cutting a {0}.", vegetable);
        }
    }
}