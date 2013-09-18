using System;
using System.Text;

namespace MobilePhone
{
    public class Battery
    {
        private BatteryType batteryModel;
        private int? batteryHoursIdle;
        private int? batteryHoursTalk;

        public Battery(BatteryType batteryModel = BatteryType.LiIon)
            : this(batteryModel, null, null)
        {
        }

        public Battery(BatteryType batteryModel, int? batteryHoursIdle)
            : this(batteryModel, batteryHoursIdle, null)
        {
        }

        public Battery(BatteryType batteryModel, int? batteryHoursIdle, int? batteryHoursTalk)
        {
            this.batteryModel = batteryModel;
            this.batteryHoursIdle = batteryHoursIdle;
            this.batteryHoursTalk = batteryHoursTalk;
        }

        public BatteryType BatteryModel
        {
            get { return this.batteryModel; }
            set
            {
                if (value != null)
                {
                    this.batteryModel = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public int? BatteryHoursIdle
        {
            get { return this.batteryHoursIdle; }
            set
            {
                if (value != null || value > 0)
                {
                    this.batteryHoursIdle = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public int? BatteryHoursTalk
        {
            get { return this.batteryHoursTalk; }
            set
            {
                if (value != null || value > 0)
                {
                    this.batteryHoursTalk = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public void InputBatteryData()
        {
            string input;
            Console.Write("Input Battery model /LiIon, NiMH or NiCd/: ");
            input = Console.ReadLine();
            switch (input)
            {
                case "LiIon":
                    BatteryModel = BatteryType.LiIon;
                    break;
                case "NiMH":
                    BatteryModel = BatteryType.NiMH;
                    break;
                case "NiCd":
                    BatteryModel = BatteryType.NiCd;
                    break;
                default:
                    throw new ArgumentException("Invalid battery model!");
            }
            Console.Write("Input battery idle hours: ");
            input = Console.ReadLine();
            BatteryHoursIdle = int.Parse(input);
            Console.Write("Input battery talk hours: ");
            input = Console.ReadLine();
            BatteryHoursTalk = int.Parse(input);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(" ___________________");
            result.AppendLine("|      Battery      |");
            result.AppendLine("|___________________|");
            result.AppendLine("Battery model: " + this.batteryModel.ToString());
            result.AppendLine("Battery idle hours: " + this.batteryHoursIdle.ToString());
            result.AppendLine("Battery talk hours: " + this.batteryHoursTalk.ToString());
            return result.ToString();
        }
    }
}
