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


        #region Заголовок окна

        private string _Title = "Основное";

        /// <summary> Заголовок окна </summary>

        public string Title
        {
            get => _Title;

            set => Set(ref _Title, value);

            //set
            //{
            //    //if (Equals(_Title, value)) return;
            //    //_Title = value;
            //    //OnPropertyChanged();

            //    Set(ref _Title, value);
            //}
        }
        #endregion

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
            WindowsManager.windowAdmin.FrameWindowUser.Navigate(new ItemsAuto());
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

        #endregion


        public WindowAdminVM()
        {

            #region Команды

            OpenPageMain = new LambdaCommand(OnOpenPageMain, CanOpenPageMain);
            OpenPageAuto = new LambdaCommand(OnOpenPageAuto, CanOpenPageAuto);

            #endregion
        }
    }
}
