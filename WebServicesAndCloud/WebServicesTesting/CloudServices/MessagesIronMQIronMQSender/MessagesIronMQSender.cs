using System;
using System.Linq;
using System.Net.Http;
using IronMQ;

namespace MessagesIronMQSender
{
    class MessagesIronMQSender
    {
        static void Main(string[] args)
        {
            string userIp = GetIPAddress();

            Client client = new Client(
                "52108dcbfefc290005000002",
                "IwTYIPBaxcLpWzw6Rciyc0IE-LY");
            IQueue queue = client.Queue("JusChatQueue");
            Console.WriteLine("Enter messages to be sent to the IronMQ server:");
            while (true)
            {
                string msg = Console.ReadLine();
                queue.Push(string.Format("{0}: {1}", userIp, msg));
                Console.WriteLine("Message sent to the IronMQ server.");
            }
        }

        public static string GetIPAddress()
        {
            HttpClient client = new HttpClient();
            var resposnse = client.GetAsync("http://icanhazip.com/").Result;
            string ipAddress = resposnse.Content.ReadAsStringAsync().Result;

            return ipAddress.Replace("\n", string.Empty);
        }
    }
}