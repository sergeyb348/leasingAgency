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
using System.Windows.Shapes;
using leasingAgency.Views.MainWindow.PagesUserWindow;
using leasingAgency.ViewsModels;

namespace leasingAgency.Views.MainWindow
{
    /// <summary>
    /// Логика взаимодействия для WindowUser.xaml
    /// </summary>
    public partial class WindowUser : Window
    {
        public WindowUser()
        {
            InitializeComponent();
            FrameWindowUser.Navigate(new ItemsAuto());
            DataContext = new WindowUserVM();
        }

        private void OpenMainPage_Click(object sender, RoutedEventArgs e)
        {
            FrameWindowUser.Navigate(new ItemsAuto());
        }

        private void OpenInfoPage_Click(object sender, RoutedEventArgs e)
        {
            FrameWindowUser.Navigate(new PageInfo());
        }
    }
}
