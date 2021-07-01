using leasingAgency.Infrastructure.Commands;
using leasingAgency.Models;
using leasingAgency.Views;
using leasingAgency.Views.MainWindow.PagesUserWindow;
using leasingAgency.ViewsModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace leasingAgency.ViewsModels.Windows
{
    class WindowAdminVM : ViewModel
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

        #region Команды

        #region OpenPageMain
        public ICommand OpenPageMain { get; }

        private bool CanOpenPageMain(object p) => true;

        private void OnOpenPageMain(object p)
        {
            WindowsManager.windowAdmin.FrameWindowUser.Navigate(new PageItemsAutoAdmin());
        }
        #endregion

        #region OpenPageAuto
        public ICommand OpenPageAuto { get; }

        private bool CanOpenPageAuto(object p) => true;

        private void OnOpenPageAuto(object p)
        {
            WindowsManager.windowAdmin.FrameWindowUser.Navigate(new PageAddAuto());
        }
        #endregion

        #region CloseWindow
        public ICommand CloseWindow { get; }

        private bool CanCloseWindow(object p) => true;

        private void OnCloseWindow(object p)
        {
            WindowsManager.ClosenWindowAdmin();
        }
        #endregion

        #region RollUpWindow
        public ICommand RollUpWindow { get; }

        private bool CanRollUpWindow(object p) => true;

        private void OnRollUpWindow(object p)
        {
            WindowsManager.windowAdmin.WindowState = System.Windows.WindowState.Minimized;
        }
        #endregion

        #region OpenPageApplication
        public ICommand OpenPageApplication { get; }

        private bool CanOpenPageApplication(object p) => true;

        private void OnOpenPageApplication(object p)
        {
            WindowsManager.windowAdmin.FrameWindowUser.Navigate(new PageApplications());
        }
        #endregion

        #region Exit
        public ICommand Exit { get; }

        private bool CanExit(object p) => true;

        private void OnExit(object p)
        {
            WindowsManager.OpenLoginWindow();
            WindowsManager.ClosenWindowAdmin();
        }

        #endregion

        #endregion


        public WindowAdminVM()
        {

            #region Команды
            OpenPageApplication = new LambdaCommand(OnOpenPageApplication, CanOpenPageApplication);
            OpenPageMain = new LambdaCommand(OnOpenPageMain, CanOpenPageMain);
            OpenPageAuto = new LambdaCommand(OnOpenPageAuto, CanOpenPageAuto);
            CloseWindow = new LambdaCommand(OnCloseWindow, CanCloseWindow);
            RollUpWindow = new LambdaCommand(OnRollUpWindow, CanRollUpWindow);
            Exit = new LambdaCommand(OnExit, CanExit);
            #endregion
        }
    }
}
