using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using leasingAgency.Views;

namespace leasingAgency.ViewsModels
{
    class mainWindowViewsModels
    {
        private Page AboutUs;
        private Page ItemsAuto;
        private Page MyProfile;

        private Page _currentPage;
        private Page CurrentPage;

        private double _frameOpacity;
        public double FrameOpacity;

        //public partial class

        public mainWindowViewsModels() 
        {
            ItemsAuto = new ItemsAuto();

            FrameOpacity = 1;

            CurrentPage = ItemsAuto;
        }
    }
}
