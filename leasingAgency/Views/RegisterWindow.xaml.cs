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
using leasingAgency.ViewsModels;
using leasingAgency.ViewsModels.Base;

namespace leasingAgency.Views
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        RegisterWindowVM registerWindowVM;

        public RegisterWindow()
        {
            InitializeComponent();
            registerWindowVM = new RegisterWindowVM();
            DataContext = registerWindowVM;
        }

        public void GetPassword()
        {
            registerWindowVM.TextBoxPasswordFirst = pwdBoxFirst.Password;
            registerWindowVM.TextBoxPasswordSecond = pwdBoxSecond.Password;
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
