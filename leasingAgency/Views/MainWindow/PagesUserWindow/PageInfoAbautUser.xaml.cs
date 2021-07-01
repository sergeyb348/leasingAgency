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
    /// Логика взаимодействия для PageInfoAbautUser.xaml
    /// </summary>
    public partial class PageInfoAbautUser : Page
    {
        public PageInfoAbautUser(int Id)
        {
            InitializeComponent();
            DataContext = new PageInfoUserVM(Id);
        }
    }
}
