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
    public class SenderReceiverEmial: INotifyPropertyChanged
    {
        [DataMember]
        private string senderEmail;
        [DataMember]
        private string receiverEmail;


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            // It means there event handler who is listning for particular event and invoke
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }


        }



        public string SenderEmailID
        {
            get { return senderEmail; }
            set
            {
                senderEmail = value; OnPropertyChanged("senderEmail");
            }
        }
        public string ReceiverEmailID
        {
            get { return receiverEmail; }
            set
            {
                receiverEmail = value; OnPropertyChanged("receiverEmail");
            }
        }
    }
}
