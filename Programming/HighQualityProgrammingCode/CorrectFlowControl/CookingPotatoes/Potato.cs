namespace CookingPotatoes
{
    class Potato
    {
        public bool HasBeenPeeled
        {
            get;
            private set;
        }

        public bool IsRotten
        {
            get;
            private set;
        }

        public Potato()
        {
            this.HasBeenPeeled = true;
            this.IsRotten = false;
        }
    }
}
