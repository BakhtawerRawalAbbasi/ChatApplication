﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [DataContract]
    public class ResponseOfHistoryMessages
    {
        [DataMember]
        public List<HistoryOfMessages> historyOfMessages;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            // It means there event handler who is listning for particular event and invoke
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }


        }

        public ResponseOfHistoryMessages(List<HistoryOfMessages> resp)
        {

            historyOfMessages = resp;
            OnPropertyChanged("resp");
        }

    }
}
