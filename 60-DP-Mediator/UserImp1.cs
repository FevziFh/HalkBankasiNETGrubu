using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _60_DP_Mediator
{
    public class UserImp1 : User
    {
        public UserImp1(IChatMediator mediator, string name) : base(mediator, name)
        {
        }

        public override void Receive(string message)
        {
            Console.WriteLine(this.name + ": Mesaj alındı: " + message);
        }

        public override void Send(string message)
        {
            Console.WriteLine(this.name + ": Mesaj Gönderildi: " + message);
            mediator.SendMessage(message,this);
        }
    }
}
