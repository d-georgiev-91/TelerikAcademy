using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;

namespace PubNubMessanger
{
    class PubNubMessanger
    {
        static void Main()
        {
            string userIp = GetIPAddress();

            // Start the HTML5 Pubnub client
            Process.Start("..\\..\\Reciever.html");

            System.Threading.Thread.Sleep(2000);

            PubnubApi pubnub = new PubnubApi(
                "pub-c-6f20d46e-4bf1-49f6-93b9-21a62176d5a8",               // PUBLISH_KEY
                "sub-c-a531d944-07f1-11e3-ab8d-02ee2ddab7fe",               // SUBSCRIBE_KEY
                "sec-c-ZjFjMzU3ZWMtNmQ4OC00ZjhhLWI3M2QtNTM4N2ZmM2Q5M2I4",   // SECRET_KEY
                true                                                        // SSL_ON?
            );
            string channel = "just-chat-channel";

            // Publish a sample message to Pubnub
            List<object> publishResult = pubnub.Publish(channel, "Welcome to just chat channel!");
            Console.WriteLine(
                "Publish Success: " + publishResult[0].ToString() + "\n" +
                "Publish Info: " + publishResult[1]
            );

            // Show PubNub server time
            object serverTime = pubnub.Time();
            Console.WriteLine("Server Time: " + serverTime.ToString());

            // Subscribe for receiving messages (in a background task to avoid blocking)
            System.Threading.Tasks.Task t = new System.Threading.Tasks.Task(
                () =>
                pubnub.Subscribe(
                    channel,
                    delegate(object message)
                    {
                        Console.WriteLine("Received Message -> '" + message + "'");
                        return true;
                    }
                )
            );
            t.Start();

            // Read messages from the console and publish them to Pubnub
            while (true)
            {
                Console.Write("Enter a message to be sent to Pubnub: ");
                string msg = Console.ReadLine();
                pubnub.Publish(channel, string.Format("{0}: {1}", userIp, msg));
                Console.WriteLine("Message \"{0}\" sent.", msg);
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
