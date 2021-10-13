using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class ResponseforLogout : INotifyPropertyChanged
    {

        private string email_id;
        private enum status { };


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



    }

}