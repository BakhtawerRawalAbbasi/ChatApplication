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
    public class ResponseSendMessage
    {
        
        [DataMember]
        public ResponseSendMessage responseSendMess;
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            // It means there event handler who is listning for particular event and invoke
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }


        }

        public ResponseSendMessage(ResponseSendMessage resp)
        {
            responseSendMess = resp; OnPropertyChanged("resp"); ;

        }
    }
}
