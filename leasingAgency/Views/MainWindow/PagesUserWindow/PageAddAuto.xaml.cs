using leasingAgency.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace leasingAgency.Views.MainWindow.PagesUserWindow
{
    /// <summary>
    /// Логика взаимодействия для PageAddAuto.xaml
    /// </summary>
    public partial class PageAddAuto : Page
    {
        public PageAddAuto()
        {
            InitializeComponent();
            DataContext = new PageAddAutoVM();
        }
    }
}
