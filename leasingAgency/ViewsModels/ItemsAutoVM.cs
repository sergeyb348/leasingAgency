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
        internal static string ItemsInfoPriceMonth(int strMonth, int strPrice) 
        {
            try 
            {
                int x = strPrice / strMonth;
                if (Convert.ToDouble(strMonth) / 12.0 != 1 && strMonth % 12 != 0)
                {
                    return "В месяц " + x + " BYN на " + strMonth / 12 + "г." + strMonth % 12 + "м.";
                }
                else if (Convert.ToDouble(strMonth) / 12.0 != 1 && strMonth % 12 == 0)
                {
                    return "В месяц " + x + " BYN на " + strMonth % 12 + "м.";
                }
                else if (Convert.ToDouble(strMonth) / 12.0 == 1 && strMonth % 12 == 0)
                {
                    return "В месяц " + x + " BYN на " + strMonth / 12 + "г.";
                }
                else 
                {
                    return "";
                }
            }
            catch 
            {
                return "";
            }

        }

        #region TextBoxSearch

        private string _TextBoxSearch;

        /// <summary> TextBoxSearch </summary>

        public string TextBoxSearch
        {
            get => _TextBoxSearch;

            set => Set(ref _TextBoxSearch, value);
        }
        #endregion


        #region itemsAuto

        private List<AutoTable> _itemsAuto;

        /// <summary> itemsAuto </summary>

        public List<AutoTable> itemsAuto
        {
            get => _itemsAuto;

            set => Set(ref _itemsAuto, value);
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
            #region Команды
            AddLikedItems = new LambdaCommand(OnAddLikedItems, CanAddLikedItems);
            #endregion
        }
    }
}
