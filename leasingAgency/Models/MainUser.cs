using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using leasingAgency.Models;

namespace leasingAgency.Models
{
    internal class MainUser
    {
        #region Singleton
        private static MainUser instance;

        public UserTable user;

        private MainUser() { }

        public static MainUser getInstance()
        {
            if (instance == null)
                instance = new MainUser();
            return instance;
        }
        #endregion
        internal static bool SetMainUser(string login, string password) 
        {
            try
            {
                LeasingAgencyContextDB context = new LeasingAgencyContextDB();
                MainUser mainUser = getInstance();
                mainUser.user = context.UserTable.First(x => x.UserLogin.Trim() == login && x.UserPassword == password);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
