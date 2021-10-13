using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public  class UserService
    {

        private static List<UserLoginRequest> UserList;
        public UserService()
        {
            UserList = new List<UserLoginRequest>();
        }

        public List<UserLoginRequest> GetAll()
        {
            return UserList;
        }
        public bool AddUser(UserLoginRequest NewUser)
        {
            UserList.Add(NewUser);
            return true;
        }
        public bool Logout(string id)
        {
            bool IsDeleted = false;
            for(int index=0; index < UserList.Count; index++ )
            {
                if(UserList[index].ID =="id" )
                {
                    UserList.RemoveAt(index);
                    IsDeleted = true;
                }
            }
            return IsDeleted;
        }
    }
}
