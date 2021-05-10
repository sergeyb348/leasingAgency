using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                leasingAgency_BDContext context = new leasingAgency_BDContext();
                User user = context.User_Table.First(x => x.User_Login == login && x.User_Password == password);
                MainUser mainUser = getInstance();
                mainUser.idUser = user.ID_User;
                mainUser.loginUser = user.User_Login;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
