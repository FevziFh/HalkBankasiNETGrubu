using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _60_DP_Mediator
{
    public class ChatMediatorImp : IChatMediator
    {
        private List<User> users;

        public ChatMediatorImp()
        {
            this.users = new List<User>();
        }

        public void AddUser(User user)
        {
            this.users.Add(user);
        }

        public void SendMessage(string msg, User user)
        {
            foreach (User u in this.users)
            {
                if (u != user)
                {
                    u.Receive(msg);
                }
            }
        }
    }
}
