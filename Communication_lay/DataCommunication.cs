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
    

        public delegate void MessageSend(object mess, string messType);

        // Event of delegate 
        public event MessageSend Mess_Send;
      
        private Client_socket client;

        Guid id = Guid.NewGuid();
        public DataCommunication()
        {
            client = new Client_socket(id.ToString());
            client.Mess_Received += Mess_Received;

        }
        public  void DataSend<T>(T t,string MessType)
        {
            //Serialization serialize = new Serialization();
            byte[] jsonString = Serialization.JsonSerializer<T>(t);
            //Client_socket client = new Client_socket("2");
            client.Send(jsonString, MessType);
           // client.Mess_Received += Mess_Received;

        }


        


       // public  void C1_Mess_Received(byte[] mess, string messType)
        //{

           // UserLoginRequest pp = Deserialization.JsonDeserialize<UserLoginRequest>(mess);
          // string name = "bakhtawer";
          // OnReceivedMess(name, messType);
          // Console.WriteLine(pp.Email);


       // }
    
        public void Mess_Received(byte[] mess, string messType)
        {
            if(messType=="Login Request")
            {
                UserLoginResponse pp = Deserialization.JsonDeserialize<UserLoginResponse>(mess);
                OnReceivedMess(pp, messType);
            }
        
            else if(messType == "Registration")
            {
                ResponsetoSignUP pp = Deserialization.JsonDeserialize<ResponsetoSignUP>(mess);
                OnReceivedMess(pp, messType);
            }


        }




        protected virtual void OnReceivedMess(object mess, string messType)
        {

            // this method notify all subscriber
            if (Mess_Send != null)
                // Raise an event
                Mess_Send(mess, messType);
        }





        static void Main(string[] args)
        {
           

        }

        }


    }
