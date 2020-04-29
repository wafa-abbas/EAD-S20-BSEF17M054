using Assignment.DAL;
using Assignment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.BAL
{
    static public class UserBO
    {
        public static UserDTO validateUser(String login, String password)
        {
            return UserDAO.validateUser(login, password);
        }
        public static int save(UserDTO user)
        {
            return UserDAO.save(user);
        }
    }
}
