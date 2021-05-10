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
using leasingAgency.Models;

namespace leasingAgency.ViewsModels
{
    internal class LoginWindowVM : ViewModel {

        #region Заголовок окна

        private string _Title = "Логин окно";

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

        #region Логин 

        /// <summary> Логин </summary>

        private bool flagLogin = false;

        private string _TextBoxLogin;

        public string TextBoxLogin
        {
            get => _TextBoxLogin;

            set {
                regexCheckLogin(value);
                Set(ref _TextBoxLogin, value);
            }
        }

        private string _TextBlockErrorLogin;

        public string TextBlockErrorLogin 
        {
            get => _TextBlockErrorLogin;

            set => Set(ref _TextBlockErrorLogin, value);
        }

        private void regexCheckLogin(string login)
        {
            if (!RegexForm.RegexLoginFunc(login)) {
                TextBlockErrorLogin = "Выбранное имя аккаунта недоступно";
                flagLogin = false;
            }
            else {
                TextBlockErrorLogin = "";
                flagLogin = true;
            }
        }
        #endregion

        #region Пароль

        /// <summary> Пароль </summary>

        private string _TextBoxPassword;

        public string TextBoxPassword
        {
            get => _TextBoxPassword;

            set
            {
                regexCheckPassword(value);
                Set(ref _TextBoxPassword, value);
            }
        }

        private string _TextBlockErrorPassword;

        public string TextBlockErrorPassword
        {
            get => _TextBlockErrorPassword;

            set => Set(ref _TextBlockErrorPassword, value);
        }

        private bool regexCheckPassword(string Password)
        {
            if (!RegexForm.RegexPasswordFunc(Password))
            {
                TextBlockErrorPassword = "Выбранный пароль недоступен";
                return false;
            }
            else
            {
                TextBlockErrorPassword = "";
                return true;
            }
        }

        #endregion

        #region Команды

        #region OpenRegisterWindow
        public ICommand OpenRegisterWindow { get; }

        private bool CanOpenRegisterWindow(object p) => true;

        private void OnOpenRegisterWindow(object p)
        {
            WindowsManager.OpenRegisterWindow();
            Application.Current.MainWindow.Close();
        }
        #endregion

        #region OpenMainWindowUser
        public ICommand OpenMainWindowUser { get; }

        private bool CanOpenMainWindowUser(object p) => flagLogin;

        private void OnOpenMainWindowUser(object p)
        {
            WindowsManager.loginWindow.SetPassword();
            if (MainUser.SetMainUser(TextBoxLogin, TextBoxPassword))
            {
                
                WindowsManager.OpenMainWindowUser();
                Application.Current.MainWindow.Close();
            }
            else 
            {
                TextBlockErrorLogin = "Неверный логин или пароль";
            }
        }
        #endregion

        #endregion

        public LoginWindowVM()
        {

            #region Команды

            OpenMainWindowUser = new LambdaCommand(OnOpenMainWindowUser, CanOpenMainWindowUser);
            OpenRegisterWindow = new LambdaCommand(OnOpenRegisterWindow, CanOpenRegisterWindow);

            #endregion
        }
    }
}
