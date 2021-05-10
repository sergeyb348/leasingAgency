using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using leasingAgency.Models;

namespace leasingAgency.Models
{
    public static class Register
    {

        public static bool addUser(string loginUser, string passwordUser) 
        {
            try
            {
                leasingAgency_BDContext context = new leasingAgency_BDContext();
                var user = new User();
                user.User_Login = loginUser;
                user.User_Password = PasswordManager.GetPassword(passwordUser);
                context.User_Table.Add(user);
                context.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
