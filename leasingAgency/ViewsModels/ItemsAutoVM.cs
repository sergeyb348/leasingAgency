using leasingAgency.Infrastructure.Commands;
using leasingAgency.Models;
using leasingAgency.ViewsModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace leasingAgency.ViewsModels
{
    internal class ItemsAutoVM : ViewModel
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
                ListAuto = Auto.Search(value, AllItemsAuto, _TextBoxFromPrice, TextBoxBeforPrice);
                Set(ref _TextBoxSearch, value);
            }
        }
        #endregion

        #region TextBoxFromPrice

        private string _TextBoxFromPrice;

        /// <summary> _TextBoxFromPrice </summary>

        public string TextBoxFromPrice
        {
            get => _TextBoxFromPrice;

            set
            {
                if (RegexForm.RegexOnlyNumberFunc(value) || value == "")
                {
                    ListAuto = Auto.Search(TextBoxSearch, AllItemsAuto, value, TextBoxBeforPrice);
                    Set(ref _TextBoxFromPrice, value);
                }
            }    
        }
        #endregion

        #region TextBoxBeforPrice

        private string _TextBoxBeforPrice;

        /// <summary> _TextBoxFromPrice </summary>

        public string TextBoxBeforPrice
        {
            get => _TextBoxBeforPrice;

            set
            {
                if (RegexForm.RegexOnlyNumberFunc(value) || value == "")
                {
                    ListAuto = Auto.Search(TextBoxSearch, AllItemsAuto, TextBoxFromPrice, value);
                    Set(ref _TextBoxBeforPrice, value);
                }
            }
        }
        #endregion

        #region AllItemsAuto

        private List<Auto> _AllItemsAuto;

        /// <summary> AllItemsAuto </summary>

        public List<Auto> AllItemsAuto
        {
            get => _AllItemsAuto;

            set => Set(ref _AllItemsAuto, value);
        }
        #endregion

        #region Команды

        #region AddLikedItems
        public ICommand AddLikedItems { get; }

        private bool CanAddLikedItems(object p) => true;

        private void OnAddLikedItems(object p)
        {
            
        }
        #endregion

        #endregion

        internal ItemsAutoVM() 
        {
            AllItemsAuto = Auto.GetListAuto();
            ListAuto = AllItemsAuto;

            _TextBoxBeforPrice = "";
            _TextBoxFromPrice = "";
            _TextBoxSearch = "";

            #region Команды
            AddLikedItems = new LambdaCommand(OnAddLikedItems, CanAddLikedItems);
            #endregion
        }
    }
}
