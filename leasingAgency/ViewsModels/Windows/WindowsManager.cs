using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using leasingAgency.Views;
using leasingAgency.Views.MainWindow;



namespace leasingAgency.ViewsModels
{
    internal static class WindowsManager
    {

        #region windowAdmin

        internal static WindowAdmin windowAdmin;

        internal static void OpenWindowAdmin()
        {
            windowAdmin = new WindowAdmin();
            windowAdmin.Show();
        }

        internal static void ClosenWindowAdmin()
        {
            windowAdmin.Close();
        }

        #endregion

        # region windowUser

        internal static WindowUser windowUser;

        internal static void OpenMainWindowUser() 
        {
            windowUser = new WindowUser();
            windowUser.Show();
        }

        internal static void CloseWindowUser() 
        {
            windowUser.Close();
        }

        #endregion

        # region registerWindow

        internal static RegisterWindow registerWindow;

        internal static void OpenRegisterWindow()
        {
            registerWindow = new RegisterWindow();
            registerWindow.Show();
        }

        internal static void CloseRegisterWindow()
        {
            registerWindow.Close();
        }

        #endregion

        #region registerWindow

        internal static LoginWindow loginWindow;

        internal static void OpenLoginWindow()
        {
            loginWindow = new LoginWindow();
            loginWindow.Show();
        }

        internal static void CloseLoginWindow()
        {
            loginWindow.Close();
        }

        #endregion
    }
}
