using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Models
{
    [DataContract]
    public class RequestToSendMess : INotifyPropertyChanged
    {

        #region property
        [DataMember]
        private string senderName;
        [DataMember]
        private string sender_Email_ID;
        [DataMember]
        private DateTime messag_SendTime;
        [DataMember]
        private string receiver_Name;
        [DataMember]
        private string receiver_Email_id;
        [DataMember]
        private string message;
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            // It means there event handler who is listning for particular event and invoke
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }


        }


        public string SenderName
        {
            get { return senderName; }
            set { senderName = value; OnPropertyChanged("senderName"); }
        }

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("message"); }
        }
        public string Sender_Email_ID
        {
            get { return sender_Email_ID; }
            set { sender_Email_ID = value; OnPropertyChanged("sender_Email_ID"); }
        }

        public DateTime Messag_SendTime
        {
            get { return messag_SendTime; }
            set { messag_SendTime = value; OnPropertyChanged("messag_SendTime"); }
        }


        public string Receiver_Name
        {
            get { return receiver_Name; }
            set { receiver_Name = value; OnPropertyChanged("receiver_Name"); }
        }
       
        public string Receiver_Email_id
        {
            get { return receiver_Email_id; }
            set { receiver_Email_id = value; OnPropertyChanged("receiver_Email_id"); }
        }
    }
}
