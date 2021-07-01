using leasingAgency.ViewsModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using leasingAgency.Views;
using System.Windows.Input;
using leasingAgency.Infrastructure.Commands;
using System.Windows;
using leasingAgency.ViewsModels;
using leasingAgency.Models;

namespace leasingAgency.ViewsModels
{
    internal class RegisterWindowVM : ViewModel
    {
        #region Заголовок окна

        private string _Title = "Окно регестрации";

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

            set
            {
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
            if (!RegexForm.RegexLoginFunc(login))
            {
                TextBlockErrorLogin = "Выбранное имя аккаунта недоступно";
                flagLogin = false;
            }
            else
            {
                TextBlockErrorLogin = "";
                flagLogin = true;
            }
        }
        #endregion

        #region Пароль 

        /// <summary> Пароль </summary> 

        #region PasswordFirst

        private string _TextBoxPasswordFirst;

        public string TextBoxPasswordFirst
        {
            get => _TextBoxPasswordFirst;

            set
            {
                regexCheckPasswordFirst(value);
                Set(ref _TextBoxPasswordFirst, value);
            }
        }

        private string _TextBlockErrorPasswordFirst;

        public string TextBlockErrorPasswordFirst
        {
            get => _TextBlockErrorPasswordFirst;

            set => Set(ref _TextBlockErrorPasswordFirst, value);
        }

        private bool regexCheckPasswordFirst(string Password)
        {
            if (!RegexForm.RegexPasswordFunc(Password))
            {
                TextBlockErrorPasswordFirst = "Выбранный пароль недоступен";
                return false;
            }
            else
            {
                TextBlockErrorPasswordFirst = "";
                return true;
            }
        }

        #endregion

        #region PasswordSecond


        private string _TextBoxPasswordSecond;

        public string TextBoxPasswordSecond
        {
            get => _TextBoxPasswordSecond;

            set
            {
                regexCheckPasswordFirst(value);
                Set(ref _TextBoxPasswordSecond, value);
            }
        }

        private string _TextBlockErrorPasswordSecond;

        public string TextBlockErrorPasswordSecond
        {
            get => _TextBlockErrorPasswordSecond;

            set => Set(ref _TextBlockErrorPasswordSecond, value);
        }

        private bool regexCheckPasswordSecond(string Password)
        {
            if (TextBoxPasswordFirst == TextBoxPasswordSecond)
            {
                TextBlockErrorPasswordSecond = "";
                return true;
            }
            else
            {
                TextBlockErrorPasswordSecond = "Пароли не совпали";
                return false;
                
            }
        }

        #endregion

        #endregion

        #region Команды

        #region OpenLoginWindow
        public ICommand OpenLoginWindow { get; }

        private bool CanOpenLoginWindow(object p) => true;

        private void OnOpenLoginWindow(object p)
        {
            WindowsManager.OpenLoginWindow();
            WindowsManager.CloseRegisterWindow();
        }
        #endregion

        #region RegisterUser
        public ICommand RegisterUser { get; }

        private bool CanRegisterUser(object p) => (flagLogin);

        private void OnRegisterUser(object p)
        {
            WindowsManager.registerWindow.GetPassword();
            if (regexCheckPasswordFirst(TextBoxPasswordFirst) && regexCheckPasswordSecond(TextBoxPasswordSecond))
            {
                if (Register.addUser(TextBoxLogin, TextBoxPasswordFirst))
                {
                    WindowsManager.OpenLoginWindow();
                    WindowsManager.CloseRegisterWindow();
                }
                else 
                {
                    TextBlockErrorLogin = "Данный логин занят";
                }
            }
        }
        #endregion

        #region CloseWindow
        public ICommand CloseWindow { get; }

        private bool CanCloseWindow(object p) => true;

        private void OnCloseWindow(object p)
        {
            WindowsManager.CloseRegisterWindow();
        }
        #endregion

        #region RollUpWindow
        public ICommand RollUpWindow { get; }

        private bool CanRollUpWindow(object p) => true;

        private void OnRollUpWindow(object p)
        {
            WindowsManager.registerWindow.WindowState = System.Windows.WindowState.Minimized;
        }
        #endregion

        #endregion

        public RegisterWindowVM() 
        {
            #region Команды

            OpenLoginWindow = new LambdaCommand(OnOpenLoginWindow, CanOpenLoginWindow);
            RegisterUser = new LambdaCommand(OnRegisterUser, CanRegisterUser);
            CloseWindow = new LambdaCommand(OnCloseWindow, CanCloseWindow);
            RollUpWindow = new LambdaCommand(OnRollUpWindow, CanRollUpWindow);

            #endregion
        }
    }


}
