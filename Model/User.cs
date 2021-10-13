using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Models
{

    public class User : INotifyPropertyChanged
    {

        private string email_id;
        private string userName;
        private string id;

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
            get{ return email_id; } 
            set
            {
                email_id = value;  OnPropertyChanged("email_id");
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
        public string ID
        {
            get { return id; }
            set
            {
                email_id = value; OnPropertyChanged("id");
            }
        }

    }
}
