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
    class PageItemsAutoAdminVM : ViewModel
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

        #region TextBoxSearch

        private string _TextBoxSearch;

        /// <summary> TextBoxSearch </summary>

        public string TextBoxSearch
        {
            get => _TextBoxSearch;

            set 
            {
                ListAuto =  Auto.Search(value, AllItemsAuto);
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

        #endregion

        internal PageItemsAutoAdminVM()
        {
            AllItemsAuto = Auto.GetListAuto();
            ListAuto = AllItemsAuto;

            #region Команды

            #endregion
        }
    }
}
