namespace FileSizeCalculator
{
    using System.IO;

    public class File
    {
        public File(string location)
        {
            this.Location = location;
            var fileInfo = new FileInfo(location);
            this.Size = fileInfo.Length;
        }

        public string Location { get; private set; }

        public long Size { get; private set; }
    }
}