using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using leasingAgency.Views;
using System.ComponentModel;
using leasingAgency.ViewsModels.Base;
using System.Text.RegularExpressions;
using leasingAgency.ViewsModels;
using leasingAgency.Infrastructure.Commands;
using System.Web.UI;
using leasingAgency.Views.MainWindow;
using leasingAgency.Views.MainWindow.PagesUserWindow;
using leasingAgency.Models;

namespace leasingAgency.ViewsModels
{
    internal class WindowUserVM : ViewModel
    {
        #region UserLogin

        private string _UserLogin;

        /// <summary> UserLogin </summary>

        public string UserLogin
        {
            get => _UserLogin;

            set => Set(ref _UserLogin, value);

            
        }
        #endregion

        #region ImgAuto

        private string _ImgAuto;

        /// <summary> ImgAuto </summary>

        public string ImgAuto
        {
            get => _ImgAuto;

            set => Set(ref _ImgAuto, value);


        }
        #endregion

        #region Команды

        #region SubmitApplication
        public ICommand SubmitApplication { get; }

        private bool CanSubmitApplication(object p) => true;

        private void OnSubmitApplication(object p)
        {
            WindowsManager.windowUser.FrameWindowUser.Navigate(new PageSubmitApplication());
        }
        #endregion

        #region OpenPageMain
        public ICommand OpenPageMain { get; }

        private bool CanOpenPageMain(object p) => true;

        private void OnOpenPageMain(object p)
        {
            WindowsManager.windowUser.FrameWindowUser.Navigate(new ItemsAuto());
        }
        #endregion

        #region OpenPageInfo
        public ICommand OpenPageProfileUser { get; }

        private bool CanOpenPageProfileUser(object p) => true;

        private void OnOpenPageProfileUser(object p)
        {
            WindowsManager.windowUser.FrameWindowUser.Navigate(new PageProfileUser());
        }
        #endregion

        #region CloseWindow
        public ICommand CloseWindow { get; }

        private bool CanCloseWindow(object p) => true;

        private void OnCloseWindow(object p)
        {
            WindowsManager.CloseWindowUser();
        }
        #endregion

        #region RollUpWindow
        public ICommand RollUpWindow { get; }

        private bool CanRollUpWindow(object p) => true;

        private void OnRollUpWindow(object p)
        {
            WindowsManager.windowUser.WindowState = System.Windows.WindowState.Minimized;
        }
        #endregion

        #endregion


        public WindowUserVM() 
        {
            try 
            {
                UserLogin = MainUser.getInstance().user.UserLogin;
                #region Команды


                SubmitApplication = new LambdaCommand(OnSubmitApplication, CanSubmitApplication);
                OpenPageMain = new LambdaCommand(OnOpenPageMain, CanOpenPageMain);
                OpenPageProfileUser = new LambdaCommand(OnOpenPageProfileUser, CanOpenPageProfileUser);
                CloseWindow = new LambdaCommand(OnCloseWindow, CanCloseWindow);
                RollUpWindow = new LambdaCommand(OnRollUpWindow, CanRollUpWindow);

                #endregion
            }
            catch 
            {
                #region Команды

                OpenPageMain = new LambdaCommand(OnOpenPageMain, CanOpenPageMain);
                OpenPageProfileUser = new LambdaCommand(OnOpenPageProfileUser, CanOpenPageProfileUser);
                CloseWindow = new LambdaCommand(OnCloseWindow, CanCloseWindow);
                RollUpWindow = new LambdaCommand(OnRollUpWindow, CanRollUpWindow);

                #endregion
            }
        }
}
}
