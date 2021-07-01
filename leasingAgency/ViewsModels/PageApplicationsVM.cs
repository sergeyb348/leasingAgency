using leasingAgency.Models;
using leasingAgency.ViewsModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace leasingAgency.ViewsModels
{
    class PageApplicationsVM : ViewModel
    {
        #region ListApplication

        private List<LeasingApplicationsModel> _ListApplication;

        /// <summary> ListAuto </summary>

        public List<LeasingApplicationsModel> ListApplication
        {
            get => _ListApplication;

            set => Set(ref _ListApplication, value);
        }
        #endregion

        #region ListApplicationAll

        private List<LeasingApplicationsModel> _ListApplicationAll;

        /// <summary> ListApplicationAll </summary>

        public List<LeasingApplicationsModel> ListApplicationAll
        {
            get => _ListApplicationAll;

            set => Set(ref _ListApplicationAll, value);
        }
        #endregion

        #region TexBoxSearhApplication

        private string _TexBoxSearhApplication;

        /// <summary> TexBoxSearhApplication </summary>

        public string TexBoxSearhApplication
        {
            get => _TexBoxSearhApplication;

            set 
            {
                ListApplication = LeasingApplicationsModel.Search(value, ListApplicationAll);
                Set(ref _TexBoxSearhApplication, value);
            }
        }
        #endregion

        

        internal PageApplicationsVM() 
        {
            ListApplicationAll = LeasingApplicationsModel.GetListApplications();
            ListApplication = ListApplicationAll;
        }
    }
}
