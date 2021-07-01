using leasingAgency.Infrastructure.Commands;
using leasingAgency.Models;
using leasingAgency.Views.MainWindow.PagesUserWindow;
using leasingAgency.ViewsModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace leasingAgency.ViewsModels
{
    class PageSubmitApplicationVM : ViewModel
    {
        #region Поля

        #region Surname 

        /// <summary> Surname </summary>

        private bool flagSurname = false;

        private string _TextBoxSurname;

        public string TextBoxSurname
        {
            get => _TextBoxSurname;

            set
            {
                regexCheckSurname(value);
                Set(ref _TextBoxSurname, value);
            }
        }

        private string _TextBlockErrorSurname;

        public string TextBlockErrorSurname
        {
            get => _TextBlockErrorSurname;

            set => Set(ref _TextBlockErrorSurname, value);
        }

        private void regexCheckSurname(string login)
        {
            if (!RegexForm.RegexNameFunc(login))
            {
                TextBlockErrorSurname = "Только символы";
                flagSurname = false;
            }
            else
            {
                TextBlockErrorSurname = "";
                flagSurname = true;
            }
        }
        #endregion

        #region Name 

        /// <summary> Name </summary>

        private bool flagName = false;

        private string _TextBoxName;

        public string TextBoxName
        {
            get => _TextBoxName;

            set
            {
                regexCheckName(value);
                Set(ref _TextBoxName, value);
            }
        }

        private string _TextBlockErrorName;

        public string TextBlockErrorName
        {
            get => _TextBlockErrorName;

            set => Set(ref _TextBlockErrorName, value);
        }

        private void regexCheckName(string login)
        {
            if (!RegexForm.RegexNameFunc(login))
            {
                TextBlockErrorName = "Только символы";
                flagName = false;
            }
            else
            {
                TextBlockErrorName = "";
                flagName = true;
            }
        }

        #endregion

        #region MiddleName 

        /// <summary> MiddleName </summary>

        private bool flagMiddleName = false;

        private string _TextBoxMiddleName;

        public string TextBoxMiddleName
        {
            get => _TextBoxMiddleName;

            set
            {
                regexCheckMiddleName(value);
                Set(ref _TextBoxMiddleName, value);
            }
        }

        private string _TextBlockErrorMiddleName;

        public string TextBlockErrorMiddleName
        {
            get => _TextBlockErrorMiddleName;

            set => Set(ref _TextBlockErrorMiddleName, value);
        }

        private void regexCheckMiddleName(string login)
        {
            if (!RegexForm.RegexNameFunc(login))
            {
                TextBlockErrorMiddleName = "Только символы";
                flagMiddleName = false;
            }
            else
            {
                TextBlockErrorMiddleName = "";
                flagMiddleName = true;
            }
        }

        #endregion

        #region PhoneNumber 

        /// <summary> PhoneNumber </summary>

        private bool flagPhoneNumber = false;

        private string _TextBoxPhoneNumber;

        public string TextBoxPhoneNumber
        {
            get => _TextBoxPhoneNumber;

            set
            {
                regexCheckPhoneNumber(value);
                Set(ref _TextBoxPhoneNumber, value);
            }
        }

        private string _TextBlockErrorPhoneNumber;

        public string TextBlockErrorPhoneNumber
        {
            get => _TextBlockErrorPhoneNumber;

            set => Set(ref _TextBlockErrorPhoneNumber, value);
        }

        private void regexCheckPhoneNumber(string number)
        {
            if (!RegexForm.RegexPhoneNumberFunc(number))
            {
                TextBlockErrorPhoneNumber = "9 цифр вашего номера";
                flagPhoneNumber = false;
            }
            else
            {
                TextBlockErrorPhoneNumber = "";
                flagPhoneNumber = true;
            }
        }
        #endregion

        #endregion

        #region Команд

        #region SubmitApplication
        public ICommand SubmitApplication { get; }

        private bool CanSubmitApplication(object p) => flagMiddleName && flagName && flagPhoneNumber && flagSurname;

        private void OnSubmitApplication(object p)
        {
            if (LeasingApplicationsModel.AddLeasingApplicationsModel(TextBoxPhoneNumber, TextBoxSurname, TextBoxName, TextBoxMiddleName))
            {
                clearTextBox();
            }
            
        }
        #endregion

        #region ClearTextBox
        public ICommand ClearTextBox { get; }

        private bool CanClearTextBox(object p) => true;

        private void OnClearTextBox(object p)
        {
            clearTextBox();
        }

        private void clearTextBox()
        {
            WindowsManager.windowUser.FrameWindowUser.Navigate(new PageSubmitApplication());
        }

        #endregion

        #endregion

        internal PageSubmitApplicationVM() 
        {
            #region Команды

            SubmitApplication = new LambdaCommand(OnSubmitApplication, CanSubmitApplication);
            ClearTextBox = new LambdaCommand(OnClearTextBox, CanClearTextBox);

            #endregion
        }
    }
}
