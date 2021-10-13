using NetMQ;
using NetMQ.Sockets;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Router_Dealer
{
    class Program
    {

        public static void Main(string[] args)
        {
            // NOTES
            // 1. Use ThreadLocal<DealerSocket> where each thread has
            //    its own client DealerSocket to talk to server
            // 2. Each thread can send using it own socket
            // 3. Each thread socket is added to poller
            using (var server = new RouterSocket("@tcp://127.0.0.1:5556"))
            {
                //using (var poller = new NetMQPoller())
                //{

                // server loop
                while (true)
                {
                    var clientMessage = server.ReceiveMultipartMessage();
                    PrintFrames("Server receiving", clientMessage);
                    if (clientMessage.FrameCount == 3)
                    {
                        var clientAddress = clientMessage[0];
                        var clientMessageType = clientMessage[1];
                        var clientOriginalMessage = clientMessage[2];
                        // string response = string.Format("Message type {1} Message back from server {1}", clientMessageType,
                        //clientOriginalMessage);
                        var messageToClient = new NetMQMessage();
                        messageToClient.Append(clientAddress);
                        messageToClient.Append(clientMessageType);
                        messageToClient.Append(clientOriginalMessage);
                       // Deserialization deserialize = new Deserialization();
                        Model pp = Deserialization.JsonDeserialize<Model>(clientOriginalMessage);
                        Console.WriteLine(pp.Email);
                        server.SendMultipartMessage(messageToClient);
                    }
                }
                //}
            }

        }
        static void PrintFrames(string operationType, NetMQMessage message)
        {
            for (int i = 0; i < message.FrameCount; i++)
            {
                Console.WriteLine("{0} Socket : Frame[{1}] = {2}", operationType, i,
                    message[i].ConvertToString());
            }
        }
    }
}

