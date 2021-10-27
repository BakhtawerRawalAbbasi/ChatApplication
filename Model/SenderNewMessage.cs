using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
 
    public class SenderNewMessage : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private static SenderNewMessage _instance;
        private string senderEmailID;
        private string senderName;
        private string message;
        private string receiverEmail;
        private DateTime messageSendTime;
        private void OnPropertyChanged(string propertyName)
        {
            // It means there event handler who is listning for particular event and invoke
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }


        }

        public static SenderNewMessage Instance => _instance ?? (_instance = new SenderNewMessage());

        public string SenderEmailID
        {
            get => senderEmailID;
            set
            {
                senderEmailID = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SenderEmailID)));
            }
        }
        public string SenderName
        {
            get => senderName;
            set
            {
                senderName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SenderName)));
            }
        }
        public string Message
        {
            get => message;
            set
            {
                message = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Message)));
            }
        }
        public string ReceiverEmailID
        {
            get => receiverEmail;
            set
            {
                receiverEmail = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ReceiverEmailID)));
            }
        }
        public DateTime MessageSendTime
        {
            get => messageSendTime;
            set
            {
                messageSendTime = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MessageSendTime)));
            }
        }
    }
}
