using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLayer
{
   public class DataCommunication
    {



        private static DataCommunication _instance;
        public static DataCommunication Instance => _instance ?? (_instance = new DataCommunication());

        public delegate void MessageSend(object mess, string messType);

        // Event of delegate 
        public event MessageSend Mess_Send;
        public delegate void MessageLoginUser(object mess, string messType);

        // Event of delegate 
        public event MessageLoginUser Mess_LoginUser;

        private Client_socket client;
        public string senderEmail;

        Guid id = Guid.NewGuid();
        private DataCommunication()
        {
            client = new Client_socket(id.ToString());
            client.Mess_Received += Mess_Received;

        }
        public  void DataSend<T>(T t,string MessType)
        {
       
            byte[] jsonString = Serialization.JsonSerializer<T>(t);
            client.Send(jsonString, MessType);
       
        }


        public void DataSend(string MessType)
        {
            
            client.Send( MessType);
          

        }



     

        public void Mess_Received(byte[] mess, string messType)
        {
            if(messType=="Login Request")
            {
                UserLoginResponse pp = Deserialization.JsonDeserialize<UserLoginResponse>(mess);

                OnReceivedMessage(pp, messType);
            }
        
            else if(messType == "Registration")
            {
                ResponsetoSignUP pp = Deserialization.JsonDeserialize<ResponsetoSignUP>(mess);
                OnReceivedMessage(pp, messType);
            }

            else if (messType == "Current User Login")
            {
                ResponsetoListUser pp = Deserialization.JsonDeserialize<ResponsetoListUser>(mess);
                OnReceivedMessage(pp, messType);
            }
            else if (messType=="Login User")
            {
                LoginUser pp = Deserialization.JsonDeserialize<LoginUser>(mess);
                OnReceivedMessage(pp, messType);

            }
            else if (messType == "Send Message Request")
            {
                ResponseSendMessage pp = Deserialization.JsonDeserialize<ResponseSendMessage>(mess);
                OnReceivedMessage(pp, messType);
            }
            else if (messType == "History of message")
            {
                ResponseOfHistoryMessages pp = Deserialization.JsonDeserialize<ResponseOfHistoryMessages>(mess);
                OnReceivedMessage(pp, messType);
            }

            else if (messType == "Message Receive Request")
            {
                RequestToSendMess pp = Deserialization.JsonDeserialize<RequestToSendMess>(mess);
                OnReceivedMessage(pp, messType);
            }

        }

        protected virtual void OnReceivedMessage(object mess, string messType)
        {

            // this method notify all subscriber
            if (Mess_Send != null)
                // Raise an event
                Mess_Send(mess, messType);
        }
        protected virtual void OnReceivedLoginUser(object mess, string messType)
        {

            // this method notify all subscriber
            if (Mess_LoginUser != null)
              // Raise an event
              Mess_LoginUser(mess, messType);
        }

        //protected virtual void OnReceivedRegistrationMessage(object mess, string messType)
        //{

        //    // this method notify all subscriber
        //    if (Mess_Send != null)
        //        // Raise an event
        //        Mess_Send(mess, messType);
        //}
        //protected virtual void OnReceivedMess(object mess, string messType)
        //{

        //    // this method notify all subscriber
        //    if (Mess_Send != null)
        //        // Raise an event
        //        Mess_Send(mess, messType);
        //}




        static void Main(string[] args)
        {
           

        }

        }


    }
