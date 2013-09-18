namespace FileSizeCalculator
{
    using System;

    class FileSizeCalculator
    {
        static void Main()
        {
            Console.Write("Loading windows directory tree...");
            Folder windowsFolder = new Folder("C:\\Windows");
            Console.Clear();
            Console.WriteLine("{0:N} bytes", windowsFolder.CalculateFileSize("C:\\Windows\\Temp"));
        }
    }
}