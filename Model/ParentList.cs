using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class ParentList
    {
        [DataMember]
        public List<UserStatus> loginUserEmail;

        [DataMember]
        public List<User> userListResponse;

    }
}
