﻿namespace MobilePhone
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Gsm
    {
        private string gsmModel;
        private string gsmManufacturer;
        private double? gsmPrice;
        private string gsmOwner;
        private Battery gsmBattery = new Battery(BatteryType.NiMH, 5, 12);
        private Display gsmDisplay = new Display(5.1);
        private List<Call> callHistory = new List<Call>();

        private static readonly Gsm iPhone4S = new Gsm("4S", "Apple", 1240, "Pesho");

        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }
            set
            {
                if (value != null)
                {
                    this.callHistory = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public static Gsm IPhone
        {
            get
            {
                return iPhone4S;
            }
        }

        public void InputGsmData()
        {
            string input;
            Console.Write("Input GSM model: ");
            input = Console.ReadLine();
            GsmModel = input;
            Console.Write("Input GSM manufacturer: ");
            input = Console.ReadLine();
            GsmManufacturer = input;
            Console.Write("Input GSM price: ");
            input = Console.ReadLine();
            GsmPrice = double.Parse(input);
            Console.Write("Input GSM Owner: ");
            input = Console.ReadLine();
            GsmOwner = input;
            gsmBattery.InputBatteryData();
            gsmDisplay.InputDisplayData();
        }

        public Gsm(string gsmModel, string gsmManufacturer)
            : this(gsmModel, gsmManufacturer, null, null, null, null)
        {
        }

        public Gsm(string gsmModel, string gsmManufacturer, int gsmPrice)
            : this(gsmModel, gsmManufacturer, gsmPrice, null, null, null)
        {
        }

        public Gsm(string gsmModel, string gsmManufacturer, double? gsmPrice, string gsmOwner)
            : this(gsmModel, gsmManufacturer, gsmPrice, gsmOwner, null, null)
        {
        }

        public Gsm(string gsmModel, string gsmManufacturer, double? gsmPrice, string gsmOwner, Battery gsmBattery, Display gsmDisplay)
        {
            this.gsmModel = gsmModel;
            this.gsmManufacturer = gsmManufacturer;
            this.gsmPrice = gsmPrice;
            this.gsmOwner = gsmOwner;
            this.gsmBattery = gsmBattery;
            this.gsmDisplay = gsmDisplay;
        }

        public Gsm()
        {
        }

        public string GsmModel
        {
            get
            {
                return this.gsmModel;
            }
            set
            {
                if (value != null)
                {
                    this.gsmModel = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public string GsmManufacturer
        {
            get
            {
                return this.gsmManufacturer;
            }
            set
            {
                if (value != null)
                {
                    this.gsmManufacturer = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public double? GsmPrice
        {
            get
            {
                return this.gsmPrice;
            }
            set
            {
                if (value != null || value >= 0)
                {
                    this.gsmPrice = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public string GsmOwner
        {
            get
            {
                return this.gsmOwner;
            }
            set
            {
                if (value != null)
                {
                    this.gsmOwner = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public Battery GsmBattery
        {
            get
            {
                return this.gsmBattery;
            }
            set
            {
                if (value != null)
                {
                    this.gsmBattery = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public Display GsmDisplay
        {
            get
            {
                return this.gsmDisplay;
            }
            set
            {
                if (value != null)
                {
                    this.gsmDisplay = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public void AddCall(string dateAndTime, string dialedPhone, int duration)
        {
            Call call = new Call(DateTime.Parse(dateAndTime), dialedPhone, duration);
            CallHistory.Add(call);
        }

        public void DeleteCallByDuration(int duration)
        {
            for (int i = 0; i < callHistory.Count; i++)
            {
                if (CallHistory[i].Duration == duration)
                {
                    CallHistory.RemoveAt(i);
                    i--;
                }
            }
        }

        public void ClearCallHistory()
        {
            CallHistory.Clear();
        }

        public double CalculateTotalPriceOfCalls(double pricePerMinute)
        {
            double totalTime = 0;
            foreach (var call in CallHistory)
            {
                totalTime += call.Duration;
            }
            double totalPrice = pricePerMinute * Math.Ceiling(totalTime / 60);
            return totalPrice;
        }

        public void PrintCallsInfo()
        {
            if (CallHistory.Count == 0)
            {
                Console.WriteLine("The history is empty.");
            }
            else
            {
                Console.WriteLine(" ___________________");
                Console.WriteLine("|    Calls  Info    |");
                Console.WriteLine("|___________________|");
                foreach (var call in CallHistory)
                {
                    Console.WriteLine(call.ToString());
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(" ___________________");
            result.AppendLine("|        GSM        |");
            result.AppendLine("|___________________|");
            result.AppendLine("Model: " + this.gsmModel);
            result.AppendLine("Manufacturer: " + this.gsmManufacturer);
            result.AppendLine("Price: " + this.gsmPrice.ToString());
            result.AppendLine("Owner: " + this.gsmOwner);
            result.AppendLine(this.gsmBattery != null ? this.gsmBattery.ToString() : "Unknown battery");
            result.AppendLine(this.gsmDisplay != null ? this.gsmDisplay.ToString() : "Unknown display");
            return result.ToString();
        }
    }
}