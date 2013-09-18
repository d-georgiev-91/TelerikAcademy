namespace CoinsProblem
{
    public class CoinCombinationCount
    {
        public CoinCombinationCount(int Value, int count)
        {
            this.Value = Value;
            this.Count = count;
        }
          
        public int Value { get; private set; }

        public int Count { get; set; }

        public override string ToString()
        {
            return this.Count + "coins x " + this.Value ;
        }
    }
}