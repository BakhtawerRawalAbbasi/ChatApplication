using NetMQ;
using NetMQ.Sockets;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommunicationLayer
{

    public class Client_socket
    {


        NetMQPoller poller;
        DealerSocket client;

       
        public delegate void MessageReceived(byte[] mess, string messType);

        // Event of delegate 
        public event MessageReceived Mess_Received;


        // public event EventHandler ClientReceiveReady;
        public Client_socket(string id)
        {
            initialize(id);
        }

        ~Client_socket()
        {
            poller.Stop();
        }
        public void initialize(string id)
        {
            //There is one server. It binds a RouterSocket which stores the inbound request's connection identity to work out
            //how to route back the response message to the correct client socket.
            poller = new NetMQPoller();
            client = new DealerSocket();
            // raise event by method
            client.ReceiveReady += Client_ReceiveReady;
            client.Options.Identity =
            Encoding.Unicode.GetBytes(id);
            client.Connect("tcp://127.0.0.1:5556");
            poller.Add(client);
            poller.RunAsync();
         

        }
        public void Send(byte[] mess, string messType)
        {

            // client needs multiple request
            var messageToServer = new NetMQMessage();
            messageToServer.Append(messType);
            messageToServer.Append(mess);
            client.SendMultipartMessage(messageToServer);

        }

        public void Send(string messType)
        {

            // client needs multiple request
            var messageToServer = new NetMQMessage();
            messageToServer.Append(messType);
            messageToServer.AppendEmptyFrame();
            client.SendMultipartMessage(messageToServer);

        }

        public void Client_ReceiveReady(object sender, NetMQSocketEventArgs e)
        {
            var message = e.Socket.ReceiveMultipartMessage();
            byte[] originalMessage =message[0].Buffer;
            //string response = message[2].ConvertToString();
           string response = message[1].ConvertToString();
            
            OnReceivedMess(message[0].Buffer, message[1].ConvertToString());

        }



        //method which raise an event 
        protected virtual void OnReceivedMess(byte[] mess, string messType)
        {
    
            if (Mess_Received != null)
                Mess_Received(mess, messType);
        }



    }
 
}

