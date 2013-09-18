namespace MatchExeFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    class MatchExeFiles
    {
        static void Main()
        {
            var windowsDirectory = Environment.GetEnvironmentVariable("windir");
            var exeFiles = GetExeFiles(windowsDirectory);
            var output = new StringBuilder();

            foreach (var file in exeFiles)
            {
                output.AppendLine(file);
            }

            Console.Write(output);
        }

        private static List<string> GetExeFiles(string directory)
        {
            List<string> exeFiles = new List<string>();
            Stack<string> stack = new Stack<string>();
            stack.Push(directory);

            while (stack.Count != 0)
            {
                var currentDirectory = stack.Pop();
                string [] matchedFiles;
                string[] subDirectories;
                try
                {
                    matchedFiles = Directory.GetFiles(currentDirectory, "*.exe");
                    subDirectories = Directory.GetDirectories(currentDirectory);
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Cannot access directory \"{0}\"", currentDirectory);
                    continue;
                }

                foreach (var file in matchedFiles)
                {
                    exeFiles.Add(file);
                }

                foreach (var dir in subDirectories)
                {
                    stack.Push(dir);
                }
                
            }

            return exeFiles;
        }
    }
}