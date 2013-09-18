namespace StringCountWithinString.Client
{
    using System;

    public class StringCountWithinString
    {
        static void Main()
        {
            ServiceStringCountWithinStringClient client = new ServiceStringCountWithinStringClient();
            int count = client.GetStringCountWithinString("pesho", "pesho qde mazna banica s praz, ah toq pesho");
            client.Close();
            Console.WriteLine(count);
        }
    }
}