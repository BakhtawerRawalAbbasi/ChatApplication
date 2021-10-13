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
    public class UserLoginRequest : INotifyPropertyChanged
    {
        [DataMember]
        private string email_id;

        [DataMember]
        private string id;
        [DataMember]
        private string password;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            // It means there event handler who is listning for particular event and invoke
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }


        }


        public string Email
        {
            get { return email_id; }
            set { email_id = value; OnPropertyChanged("email_id"); }
        }
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("password"); }
        }
        public string ID
        {
            get { return id; }
            set { id = value; OnPropertyChanged("password"); }
        }
    }
}
