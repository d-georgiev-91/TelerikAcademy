using System;
using System.Text;

class PrintASCIITable
{
    static void Main()
    {
        Console.Write("Decimal".PadRight(10));
        Console.Write("ASCII".PadRight(10));
        Console.Write("Hex".PadRight(10));
        Console.WriteLine();
        Console.OutputEncoding = Encoding;
        for (int i = 0; i <= 255; i++)
        {
            if (char.IsWhiteSpace((char)i))
            {
                switch ((char)i)
                {
                    case '\t':
                        Console.Write(i.ToString().PadRight(10));
                        Console.Write("\\t".PadRight(10));
                        Console.WriteLine(i.ToString("X2"));
                        break;
                    case ' ':
                        Console.Write(i.ToString().PadRight(10));
                        Console.Write("space".PadRight(10));
                        Console.WriteLine(i.ToString("X2"));
                        break;
                    case '\n':
                        Console.Write(i.ToString().PadRight(10));
                        Console.Write("\\n".PadRight(10));
                        Console.WriteLine(i.ToString("X2"));
                        break;
                    case '\r':
                        Console.Write(i.ToString().PadRight(10));
                        Console.Write("\\r".PadRight(10));
                        Console.WriteLine(i.ToString("X2"));
                        break;
                    case '\v':
                        Console.Write(i.ToString().PadRight(10));
                        Console.Write("\\v".PadRight(10));
                        Console.WriteLine(i.ToString("X2"));
                        break;
                    case '\f':
                        Console.Write(i.ToString().PadRight(10));
                        Console.Write("\\f".PadRight(10));
                        Console.WriteLine(i.ToString("X2"));
                        break;
                }
            }
            else if (char.IsControl((char)i))
            {
                Console.Write(i.ToString().PadRight(10));
                Console.Write("control".PadRight(10));
                Console.WriteLine(i.ToString("X2"));
            }
            else
            {
                Console.Write(i.ToString().PadRight(10));
                Console.Write(((char)i).ToString().PadRight(10));
                Console.WriteLine(i.ToString("X2"));
        
            }
        }
    }
}
