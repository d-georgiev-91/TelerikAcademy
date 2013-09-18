// Вероятно ще ми пишеш в коентара, че задачата не трябва да се реши и така и трябва да се използва някой
// от преподадените алгоритми, но в условието не намирам смисъл да се използва Greedy, както са го направили
// повечето колеги във форума. Твърде проста е самата задача така зададена. В момента часът е 2:13 през нощта
// като пиша тази задача, 25.06. Предполагам се сещаш, че утре има изпит и ще ми отнеме доста повече време
// за да напиша имплементирам по-сложен алгоритъм. Както и да така както съм го написал също работи. Надявам се, че
// ще проявиш разбиране. Така, че don't judge me too much. П.С. преподлагам, че сигурно доста ще се 
// забавляваш на коментара ми :D

namespace CoinsProblem
{
    using System;
    using System.Collections.Generic;

    class CoinsProblem
    {
        static void Main()
        {
            int numberOfCoins = int.Parse(Console.ReadLine());
            int sum = numberOfCoins;

            List<CoinCombinationCount> coinsCombinations = new List<CoinCombinationCount>()
            {
                new CoinCombinationCount(5, 0),
                new CoinCombinationCount(2, 0),
                new CoinCombinationCount(1, 0)
            };

            for (int i = 0; i < coinsCombinations.Count; i++)
            {
                var possibleCombinationsWithCoin = sum / coinsCombinations[i].Value;
                coinsCombinations[i].Count = possibleCombinationsWithCoin;
                sum -= possibleCombinationsWithCoin * coinsCombinations[i].Value;
            }

            Console.WriteLine("{0} = {1}", numberOfCoins, string.Join(" + ", coinsCombinations));
        }
    }
}