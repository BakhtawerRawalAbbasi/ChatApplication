using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [DataContract]
    public class HistoryOfMessages
    {
        [DataMember]
        private string messages;
        [DataMember]
       
        private DateTime messageSentTime;
        [DataMember]
        private string senderEmail;
        [DataMember]
        private string senderName;
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            // It means there event handler who is listning for particular event and invoke
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }


        }
        public string Messages
        {
            get { return messages; }
            set { messages = value; OnPropertyChanged("messages"); }
        }
        public DateTime MessageSentTime
        {
            get { return messageSentTime; }
            set { messageSentTime = value; OnPropertyChanged("messageSentTime"); }
        }
        public string SenderEmail
        {
            get { return senderEmail; }
            set { senderEmail = value; OnPropertyChanged("messageSentTime"); }
        }
        public string SenderName
        {
            get { return senderName; }
            set { senderName = value; OnPropertyChanged("senderName"); }
        }
    }
}
