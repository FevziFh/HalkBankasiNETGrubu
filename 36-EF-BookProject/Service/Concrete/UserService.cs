using _36_EF_BookProject.Context;
using _36_EF_BookProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _36_EF_BookProject.Service.Concrete
{
    public class UserService : BaseCRUD<User>
    {
        public UserService(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
