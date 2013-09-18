using System;
using System.Linq;
using System.Threading;
using IronMQ;
using IronMQ.Data;

namespace MessagesIronMQReciever
{
    class MessagesIronMQReciever
    {
        static void Main()
        {
            Client client = new Client(
                "52108dcbfefc290005000002",
                "IwTYIPBaxcLpWzw6Rciyc0IE-LY");
            IQueue queue = client.Queue("JusChatQueue");
            Console.WriteLine("Listening for new messages from IronMQ server:");
            while (true)
            {
                Message msg = queue.Get();
                if (msg != null)
                {
                    Console.WriteLine(msg.Body);
                    queue.DeleteMessage(msg);
                }
                Thread.Sleep(100);
            }
        }
    }   
}
