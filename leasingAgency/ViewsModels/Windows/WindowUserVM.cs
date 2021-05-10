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
            
        }
        #endregion

        #region OpenPageInfo
        public ICommand OpenPageInfo { get; }

        private bool CanOpenPageInfo(object p) => true;

        private void OnOpenPageInfo(object p)
        {
            
        }
        #endregion

        #endregion


        public WindowUserVM() 
        {
            UserLogin = MainUser.getInstance().GetloginUser();

            #region Команды

            OpenPageMain = new LambdaCommand(OnOpenPageMain, CanOpenPageMain);
            OpenPageInfo = new LambdaCommand(OnOpenPageInfo, CanOpenPageInfo);

            #endregion
        }
}
}
