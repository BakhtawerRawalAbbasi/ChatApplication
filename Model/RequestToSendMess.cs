using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Models
{
    class RequestToSendMess 
    {

        #region property
        private string senderName;
        private string sender_Email_ID;
        private string messag_SendTime;
        private string receiver_Name;
        private string receiver_Email_id;
        #endregion

      

        public string SenderName
        {
            get { return senderName; }
            set { senderName = value; }
        }
        public string Sender_Email_ID
        {
            get { return sender_Email_ID; }
            set { sender_Email_ID = value;  }
        }

        public string Messag_SendTime
        {
            get { return messag_SendTime; }
            set { messag_SendTime = value; }
        }


        public string Receiver_Name
        {
            get { return receiver_Name; }
            set { receiver_Name = value;}
        }
       
        public string Receiver_Email_id
        {
            get { return receiver_Email_id; }
            set { receiver_Email_id = value;  }
        }
    }
}
