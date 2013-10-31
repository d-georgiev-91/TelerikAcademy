using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    class AnimalsTest
    {
        public static IEnumerable<Tuple<string, double>> AverageAgeOfKindofAnimals(ICollection<Animal> animals)
        {
            var averageAges =
                             from animal in animals
                             group animal by animal.GetType()
                                 into typeofAnimal
                                 select new Tuple<string, double>(typeofAnimal.Key.Name, typeofAnimal.Average(a => a.Age));
            return averageAges;
        }

        static void Main()
        {
            ICollection<ISound> animalsThatMakeSounds = new List<ISound>(new ISound[]
            {
                new Kitten("kitty 1", 2),
                new Kitten("kitty 2", 3),
                new Tomcat("Tom", 6),
                new Tomcat("Silvester", 9),
                new Dog("Mailo", 12, Sex.Male),
                new Dog("Sara", 4, Sex.Female),
                new Frog("Frog#1", 5, Sex.Female),
                new Frog("Frog#2", 2, Sex.Male),
            });

            ICollection<Animal> animals = new List<Animal>(new Animal[]
            {
                new Kitten("kitty 1", 2),
                new Kitten("kitty 2", 3),
                new Tomcat("Tom", 6),
                new Tomcat("Silvester", 9),
                new Dog("Mailo", 12, Sex.Male),
                new Dog("Sara", 4, Sex.Female),
                new Frog("Frog#1", 5, Sex.Female),
                new Frog("Frog#2", 2, Sex.Male),
            });

            foreach (var animal in animalsThatMakeSounds)
            {
                animal.Sound();
            }

            Console.WriteLine();

            var averageAges = AverageAgeOfKindofAnimals(animals);

            foreach (var tuple in averageAges)
            {
                Console.WriteLine("{0} {1:F2}", tuple.Item1, tuple.Item2);
            }
        }
    }
}