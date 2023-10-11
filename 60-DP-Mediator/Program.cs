namespace _60_DP_Mediator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IChatMediator mediator = new ChatMediatorImp();
            User user1 = new UserImp1(mediator,"Fatih");
            User user2 = new UserImp1(mediator, "Furkan");
            User user3 = new UserImp1(mediator, "Mehmet Ali");
            User user4 = new UserImp1(mediator, "Göktuğ");
            User user5 = new UserImp1(mediator, "Fevzi");

            mediator.AddUser(user1);
            mediator.AddUser(user2);
            mediator.AddUser(user3);
            mediator.AddUser(user4);
            mediator.AddUser(user5);

            user4.Send("Merhaba C#");
        }
    }
}