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
using leasingAgency.Models;
using leasingAgency.ViewsModels;

namespace leasingAgency.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary> 
    
    public partial class LoginWindow : Window
    {
        LoginWindowVM loginWindowVM;

        public LoginWindow()
        {
            WindowsManager.loginWindow = this;
            InitializeComponent();
            loginWindowVM = new LoginWindowVM();
            DataContext = loginWindowVM;
        }

        public void SetPassword()
        {
            loginWindowVM.TextBoxPassword = PasswordManager.GetHash(PwdBox.Password);
        }
    }
}
