using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace leasingAgency.Models
{
    class Auto : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string nameAuto
        {
            get { return nameAuto; }

            set
            {
                nameAuto = value;
                OnPropertyChanged("nameAuto");
            }
        }

        public string priceAuto
        {
            get { return priceAuto; }

            set
            {
                nameAuto = value;
                OnPropertyChanged("priceAuto");
            }
        }

        public string infoAuto
        {
            get { return infoAuto; }

            set
            {
                infoAuto = value;
                OnPropertyChanged("infoAuto");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
