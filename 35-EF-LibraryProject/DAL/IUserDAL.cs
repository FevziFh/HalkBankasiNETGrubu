using _35_EF_LibraryProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _35_EF_LibraryProject.DAL
{
    public interface IUserDAL
    {
        void AddUser(User user);
        bool UserAccount(User user);
        void DeleteUser(User user);
        void UpdateUser(User user);
    }
}
