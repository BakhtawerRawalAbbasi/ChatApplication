﻿using Models;
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
                OnReceivedMess(pp, messType);
            }
        
            else if(messType == "Registration")
            {
                ResponsetoSignUP pp = Deserialization.JsonDeserialize<ResponsetoSignUP>(mess);
                OnReceivedMess(pp, messType);
            }

            else if (messType == "Current User Login")
            {
                ResponsetoListUser pp = Deserialization.JsonDeserialize<ResponsetoListUser>(mess);
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
