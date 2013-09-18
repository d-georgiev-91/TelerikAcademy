namespace FileSizeCalculator
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Folder
    {
        private string name;
        private File[] files;
        private Folder[] childFolders;
        
        public Folder(string name)
        {
            this.Name = name.ToLower();
            this.Files = GetFiles(name);
            this.ChildFolders = GetChildFolders(name);
        }

        private Folder[] GetChildFolders(string name)
        {
            string[] foldersPath;

            try
            {
                foldersPath = Directory.GetDirectories(name);
            }
            catch (UnauthorizedAccessException)
            {
                return null;
            }

            Folder[] folders = new Folder[foldersPath.Length];

            for (int i = 0; i < folders.Length; i++)
            {
                folders[i] = new Folder(foldersPath[i]);
            }

            return folders;
        }

        private File[] GetFiles(string name)
        {
            string[] filesPath;
            
            try
            {
                filesPath = Directory.GetFiles(name);
            }
            catch (UnauthorizedAccessException)
            {
                return null;
            }

            var files = new File[filesPath.Length];

            for (int i = 0; i < files.Length; i++)
            {
                files[i] = new File(filesPath[i]);
            }

            return files;
        }

        public long CalculateFileSize(string subDirectoryPath)
        {
            long size = 0;
            Stack<Folder> stack = new Stack<Folder>();
            stack.Push(GetSubDirectory(subDirectoryPath.ToLowerInvariant()));

            while (stack.Count != 0)
            {
                var currentDirectory = stack.Pop();

                foreach (var file in currentDirectory.files)
                {
                    size += file.Size;
                }

                foreach (var childFolder in currentDirectory.ChildFolders)
                {
                    stack.Push(childFolder);
                }
            }
            return size;
        }

        private Folder GetSubDirectory(string subDirectoryPath)
        {
            Queue<Folder> queue = new Queue<Folder>();
            queue.Enqueue(this);
            while (queue.Count != 0)
            {
                var currentDirectory = queue.Dequeue();

                if (currentDirectory.Name == subDirectoryPath)
                {
                    return currentDirectory;
                }

                foreach (var childFolder in currentDirectory.ChildFolders)
                {
                    queue.Enqueue(childFolder);
                }
            }

            throw new ArgumentException("No such directory!");
        }

        public File[] Files
        {
            get
            {
                return this.files;
            }
            private set
            {
                this.files = value;
            }
        }

        public Folder[] ChildFolders
        {
            get
            {
                return this.childFolders;
            }
            private set
            {
                this.childFolders = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }
    }
}