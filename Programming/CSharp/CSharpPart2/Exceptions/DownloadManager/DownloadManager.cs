using System;
using System.Net;
using System.IO;

namespace DownloadManager
{
    class DownloadManager
    {
        static long GetFileSize(string url)
        {
            System.Net.WebRequest req = System.Net.HttpWebRequest.Create(url);
            req.Method = "HEAD";
            
            System.Net.WebResponse resp = req.GetResponse();
            long contentLength;
            long.TryParse(resp.Headers.Get("Content-Length"), out contentLength);
            return contentLength;
        }

        static long GetTotalFreeSpace(string driveName)
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.Name == driveName)
                {
                    return drive.TotalFreeSpace;
                }
            }
            return -1;
        }

        static bool ConnectionStatus(string fileUrl)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(fileUrl);
            using (HttpWebResponse rsp = (HttpWebResponse)req.GetResponse())
            {
                if (rsp.StatusCode == HttpStatusCode.OK)
                {
                    Console.WriteLine("Connection succesfull!");
                    return true;
                }
            }
            return false;
        }

        static void DownloadStatus(string fileUrl, string downloadedFile)
        {
            if (GetFileSize(fileUrl)==(GetFileSize(downloadedFile)))
            {
                Console.WriteLine("Download complete!");
            }
        }

        static void Main()
        {
            WebClient webClient = new WebClient();
            try
            {
                Console.Write("Input url: ");
                string fileUrl = Console.ReadLine();
                Console.WriteLine("Atempting to connect... ");
                string directoryToSave = null;
                if (ConnectionStatus(fileUrl))
                {
                    if (GetFileSize(fileUrl) < GetTotalFreeSpace(Path.GetPathRoot(Directory.GetCurrentDirectory()).ToUpper()))
                    {
                        directoryToSave = Directory.GetCurrentDirectory() + "\\" + Path.GetFileName(fileUrl);
                        webClient.DownloadFile(fileUrl, directoryToSave);
                    }
                    else
                    {
                        Console.WriteLine("Not enough free space to download the file!");
                    }
                }
                DownloadStatus(fileUrl, directoryToSave);
            }
            catch (UriFormatException)
            {
                Console.Error.WriteLine("Invalid URL address!");
            }
            catch (NotSupportedException)
            {
                Console.Error.WriteLine("Invalid URI preffix!");
            }
            catch (ArgumentNullException)
            {
                Console.Error.WriteLine("No address entered!");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid URL address or empty!");
            }
            catch (WebException)
            {
                Console.Error.WriteLine("Cannot connect to address!\nIt's possible that file does not exsist or sever is down\nor you don't have internet connection.");
                return;
            }
        }
    }
}
