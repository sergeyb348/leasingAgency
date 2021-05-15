﻿using leasingAgency.Views.MainWindow.PagesUserWindow;
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

namespace leasingAgency.Views
{
    /// <summary>
    /// Логика взаимодействия для ItemsAuto.xaml
    /// </summary>
    public partial class ItemsAuto : Page
    {
        public ItemsAuto()
        {
            InitializeComponent();
            DataContext = new ItemsAutoVM();
        }
    }
}
