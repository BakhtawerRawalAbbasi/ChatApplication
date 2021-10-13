using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace Models
{
    public class RequestforLogout
    {
        private string email_id;

        public string Emailid
        {
            get { return email_id; }
            set { email_id = value;  }
        }
        
    }
}
