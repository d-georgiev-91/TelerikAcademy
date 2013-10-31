namespace MobilePhone
{
    using System;
    using System.Text;

    public class Display
    {
        private double? displaySize;
        private int? numberOfColors;

        public Display()
        {
        }

        public Display(double displaySize)
            : this(displaySize, null)
        {
        }

        public Display(double displaySize, int? numberOfColors)
        {
            this.displaySize = displaySize;
            this.numberOfColors = numberOfColors;
        }


        public double? DisplaySize
        {
            get { return this.displaySize; }
            set
            {
                if (value != null || value > 0)
                {
                    this.displaySize = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public int? NumberOfColors
        {
            get { return this.numberOfColors; }
            set
            {
                if (value != null || value > 1)
                {
                    this.numberOfColors = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public void InputDisplayData()
        {
            string input;
            Console.Write("Input display size: ");
            input = Console.ReadLine();
            DisplaySize = double.Parse(input);
            Console.Write("Input number of colors: ");
            input = Console.ReadLine();
            DisplaySize = int.Parse(input);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(" ___________________");
            result.AppendLine("|      Display      |");
            result.AppendLine("|___________________|");
            result.AppendLine("Diplay size: " + this.displaySize.ToString());
            result.AppendLine("Number of colors: " + this.numberOfColors.ToString());
            return result.ToString();
        }
    }
}