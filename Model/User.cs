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
    public class User : INotifyPropertyChanged
    {
        [DataMember]
        private string email_id;
        [DataMember]
        private string userName;
     

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            // It means there event handler who is listning for particular event and invoke
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }


        }
 

       
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value; OnPropertyChanged("userName");
            }
        }

        public string EmailID
        {
            get { return email_id; }
            set
            {
                email_id = value; OnPropertyChanged("userName");
            }
        }
       

    }
}
