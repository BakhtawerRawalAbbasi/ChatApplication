using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [DataContract]
    public class ResponsetoListUser 
    {
        [DataMember]
        public List<User> userListResponse;
  

        //{ get; set; }



        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            // It means there event handler who is listning for particular event and invoke
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

            }


        }

        public ResponsetoListUser(List<User> resp)
        {

            userListResponse = resp;
            OnPropertyChanged("resp"); 
        }

       
    }
}
