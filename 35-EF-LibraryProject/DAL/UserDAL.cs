using _35_EF_LibraryProject.Context;
using _35_EF_LibraryProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _35_EF_LibraryProject.DAL
{
    public class UserDAL : IUserDAL
    {
        private readonly AppDbContext context;
        public UserDAL(AppDbContext context)
        {
            this.context = context;
        }

        public void AddUser(User user)
        {
            if (UserAccount(user))
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
            else
                throw new Exception("aynı kullanıcı kayıtlı");           
        }

        public void DeleteUser(User user)
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
        public bool UserAccount(User user)
        {
            if (context.Users.Any(x => x.Mail == user.Mail && x.UserName == user.UserName))
            {
                return false;
            }
            else 
                return true;
        }
    }
}
