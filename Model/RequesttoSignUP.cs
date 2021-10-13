using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace Models
{
   public class RequesttoSignUP 
    {
        private string userName;
        private string email_id;
        private string password;

      
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string Email
        {
            get { return email_id; }
            set { email_id = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value;  }
        }
    }
}
