using System;
using System.Collections.Generic;

namespace DocumentSystem
{
    public class DocumentSystem
    {
        private static IList<IDocument> documents = new List<IDocument>();

        static void Main()
        {
            IList<string> allCommands = ReadAllCommands();
            ExecuteCommands(allCommands);
        }

        private static IList<string> ReadAllCommands()
        {
            List<string> commands = new List<string>();
            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == "")
                {
                    // End of commands
                    break;
                }
                commands.Add(commandLine);
            }
            return commands;
        }

        private static void ExecuteCommands(IList<string> commands)
        {
            foreach (var commandLine in commands)
            {
                int paramsStartIndex = commandLine.IndexOf("[");
                string cmd = commandLine.Substring(0, paramsStartIndex);
                int paramsEndIndex = commandLine.IndexOf("]");
                string parameters = commandLine.Substring(
                    paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
                ExecuteCommand(cmd, parameters);
            }
        }

        private static void ExecuteCommand(string cmd, string parameters)
        {
            string[] cmdAttributes = parameters.Split(
                new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (cmd == "AddTextDocument")
            {
                AddTextDocument(cmdAttributes);
            }
            else if (cmd == "AddPDFDocument")
            {
                AddPdfDocument(cmdAttributes);
            }
            else if (cmd == "AddWordDocument")
            {
                AddWordDocument(cmdAttributes);
            }
            else if (cmd == "AddExcelDocument")
            {
                AddExcelDocument(cmdAttributes);
            }
            else if (cmd == "AddAudioDocument")
            {
                AddAudioDocument(cmdAttributes);
            }
            else if (cmd == "AddVideoDocument")
            {
                AddVideoDocument(cmdAttributes);
            }
            else if (cmd == "ListDocuments")
            {
                ListDocuments();
            }
            else if (cmd == "EncryptDocument")
            {
                EncryptDocument(parameters);
            }
            else if (cmd == "DecryptDocument")
            {
                DecryptDocument(parameters);
            }
            else if (cmd == "EncryptAllDocuments")
            {
                EncryptAllDocuments();
            }
            else if (cmd == "ChangeContent")
            {
                ChangeContent(cmdAttributes[0], cmdAttributes[1]);
            }
            else
            {
                throw new InvalidOperationException("Invalid command: " + cmd);
            }
        }

        private static void AddDocument(string[] attributes, IDocument document)
        {
            foreach (var attribute in attributes)
            {
                string[] tokens = attribute.Split('=');
                string key = tokens[0];
                string value = tokens[1];
                document.LoadProperty(key, value);
            }
            documents.Add(document);
            if (document.Name != null)
            {
                Console.WriteLine("Document added: {0}", document.Name);
            }
            else
            {
                Console.WriteLine("Document has no name");
            }
        }

        private static void AddTextDocument(string[] attributes)
        {
            AddDocument(attributes, new TextDocument());
        }

        private static void AddPdfDocument(string[] attributes)
        {
            AddDocument(attributes, new PDFDocument());
        }

        private static void AddWordDocument(string[] attributes)
        {
            AddDocument(attributes, new WordDocument());
        }

        private static void AddExcelDocument(string[] attributes)
        {
            AddDocument(attributes, new ExcelDocument());
        }

        private static void AddAudioDocument(string[] attributes)
        {
            AddDocument(attributes, new AudioDocument());
        }

        private static void AddVideoDocument(string[] attributes)
        {
            AddDocument(attributes, new VideoDocument());
        }

        private static void ListDocuments()
        {
            if (documents.Count == 0)
            {
                Console.WriteLine("No documents found");
            }
            else
            {
                foreach (var document in documents)
                {
                    Console.WriteLine(document);
                }
            }
        }

        private static void EncryptDocument(string name)
        {
            bool isDocumentFound = false;

            foreach (var document in documents)
            {
                if (document.Name == name)
                {
                    if (document is IEncryptable)
                    {
                        ((IEncryptable)document).Encrypt();
                        Console.WriteLine("Document encrypted: {0}", document.Name);
                    }
                    else
                    {
                        Console.WriteLine("Document does not support encryption: {0}", document.Name);
                    }
                    isDocumentFound = true;
                }
            }

            if (!isDocumentFound)
            {
                Console.WriteLine("Document not found: {0}", name);
            }
        }

        private static void DecryptDocument(string name)
        {
            bool isDocumentFound = false;

            foreach (var document in documents)
            {
                if (document.Name == name)
                {
                    if (document is IEncryptable)
                    {
                        ((IEncryptable)document).Decrypt();
                        Console.WriteLine("Document decrypted: {0}", document.Name);
                    }
                    else
                    {
                        Console.WriteLine("Document does not support decryption: {0}", document.Name);
                    }
                    isDocumentFound = true;
                }
            }

            if (!isDocumentFound)
            {
                Console.WriteLine("Document not found: {0}", name);
            }
        }

        private static void EncryptAllDocuments()
        {
            bool nonDecryptableDocuments = false;

            foreach (var document in documents)
            {
                if (document is IEncryptable)
                {
                    ((IEncryptable)document).Decrypt();
                    nonDecryptableDocuments = true;
                }
            }

            if (nonDecryptableDocuments)
            {
                Console.WriteLine("All documents encrypted");
            }
            else
            {
                Console.WriteLine("No encryptable documents found");
            }
        }

        private static void ChangeContent(string name, string content)
        {
            bool isDocumentFound = false;

            foreach (var document in documents)
            {
                if (document.Name == name)
                {
                    isDocumentFound = true;
                    if (document is IEditable)
                    {
                        ((IEditable)document).ChangeContent(content);
                        Console.WriteLine("Document content changed: {0}", document.Name);
                    }
                    else
                    {
                        Console.WriteLine("Document content changed: {0}", document.Name);
                    }
                }
            }
            if (!isDocumentFound)
            {
                Console.WriteLine("Document not found: {0}", name);
            }
        }
    }
}