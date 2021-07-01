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
                LeasingAgencyContextDB context = new LeasingAgencyContextDB();
                var user = new UserTable();
                user.UserLogin = loginUser;
                user.UserPassword = PasswordManager.GetHash(passwordUser);
                context.UserTable.Add(user);
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
