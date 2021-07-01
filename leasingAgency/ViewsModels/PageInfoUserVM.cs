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

namespace leasingAgency.ViewsModels
{
    class PageInfoUserVM : ViewModel
    {
        #region ListAuto

        private List<Auto> _ListAuto;

        /// <summary> ListAuto </summary>

        public List<Auto> ListAuto
        {
            get => _ListAuto;

            set => Set(ref _ListAuto, value);
        }
        #endregion

        #region TextBlockLoginPhoneNumber

        private string _TextBlockLoginPhoneNumber;

        /// <summary> LoginUser </summary>

        public string TextBlockLoginPhoneNumber
        {
            get => _TextBlockLoginPhoneNumber;

            set
            {
                Set(ref _TextBlockLoginPhoneNumber, value);
            }
        }
        #endregion

        #region TextBlockName

        private string _TextBlockName;

        /// <summary> TextBlocName </summary>

        public string TextBlockName
        {
            get => _TextBlockName;

            set
            {
                Set(ref _TextBlockName, value);
            }
        }
        #endregion

        #region TextBoxSearch

        private string _TextBoxSearch;

        /// <summary> TextBoxSearch </summary>

        public string TextBoxSearch
        {
            get => _TextBoxSearch;

            set
            {
                ListAuto = Auto.Search(value, AllItemsAuto);
                Set(ref _TextBoxSearch, value);
            }
        }
        #endregion

        #region itemsAuto

        private List<Auto> _AllItemsAuto;

        /// <summary> itemsAuto </summary>

        public List<Auto> AllItemsAuto
        {
            get => _AllItemsAuto;

            set => Set(ref _AllItemsAuto, value);
        }
        #endregion

        #region Команды

        #region Exit
        public ICommand Back { get; }

        private bool CanBack(object p) => true;

        private void OnBack(object p)
        {
            WindowsManager.windowAdmin.FrameWindowUser.Navigate(new PageApplications());
        }

        #endregion

        #endregion

        internal PageInfoUserVM(int Id)
        {
            AllItemsAuto = Auto.GetListLikedAuto(Id);
            ListAuto = AllItemsAuto;

            LeasingAgencyContextDB contextDB = new LeasingAgencyContextDB();
            var user = contextDB.UserTable.First(x => x.IdUser == Id);
            var app = contextDB.LeasingApplications.First(x => x.IdUser == Id);

            TextBlockLoginPhoneNumber = user.UserLogin.Trim() + "     Номер: " + app.PhoneNumber.Trim() + "      Дата: " + app.DataApplications.Trim();
            TextBlockName = app.Surname.Trim() + " " + app.NameUser.Trim() + " " + app.MiddleName.Trim();

            #region Команды

            Back = new LambdaCommand(OnBack, CanBack);

            #endregion
        }
    }
}
