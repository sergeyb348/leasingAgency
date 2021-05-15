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

        public static MainUser getInstance()
        {
            if (instance == null)
                instance = new MainUser();
            return instance;
        }
        #endregion

        #region InfoUser
        private int idUser { get; set; }

        internal int GetIdUser() 
        {
            return idUser;
        }

        private string loginUser { get; set; }

        internal string GetloginUser() 
        {
            return loginUser;
        }

        #endregion

        internal static bool SetMainUser(string login, string password) 
        {
            try
            {
                leasingAgencyBD context = new leasingAgencyBD();
                UserTable user = context.UserTable.First(x => x.UserLogin.Trim() == login && x.UserPassword == password);
                MainUser mainUser = getInstance();
                mainUser.idUser = user.IdUser;
                mainUser.loginUser = user.UserLogin;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
