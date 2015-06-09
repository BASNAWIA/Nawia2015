using BAS.Nawia.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAS.Nawia.Common.Interfaces
{
    public interface IUserService
    {
        ICollection<UserModel> GetAll();
        UserModel Get(string _id);
        UserModel GetByUsername(string username);
        ICollection<UserModel> GetUsersByRole(string _id);
        void UpdateUser(UserModel User);
    }
}
