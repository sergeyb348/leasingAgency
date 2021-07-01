using leasingAgency.Infrastructure.Commands;
using leasingAgency.Views.MainWindow.PagesUserWindow;
using leasingAgency.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace leasingAgency.Models
{
    class LeasingApplicationsModel
    {
        public int IdUser { get; set; }
        public string PhoneNumber { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string SurnameNameMiddleName { get; set; }
        public string DataApplications { get; set; }

        internal LeasingApplicationsModel(LeasingApplications x) 
        {
            IdUser = x.IdUser;
            DataApplications = x.DataApplications.Trim();
            PhoneNumber = x.PhoneNumber.Trim() + "                            Дата: " + DataApplications;
            Surname = x.Surname.Trim();
            Name = x.NameUser.Trim();
            MiddleName = x.MiddleName.Trim();
            SurnameNameMiddleName = Surname + " " + Name + " " + MiddleName;
            #region Команды

            DeletApplication = new LambdaCommand(OnDeletApplication, CanDeletApplication);
            OpenInfoUser = new LambdaCommand(OnOpenInfoUser, CanOpenInfoUser);
            #endregion
        }

        internal static bool deleteApplication(int ID) 
        {
            LeasingAgencyContextDB context = new LeasingAgencyContextDB();
            LeasingApplications ap = context.LeasingApplications.First(x => x.IdUser == ID);
            context.LeasingApplications.Remove(ap);
            context.SaveChanges();
            return true;
        }
        internal static List<LeasingApplicationsModel> GetListApplications() 
        {
            LeasingAgencyContextDB context = new LeasingAgencyContextDB();
            List<LeasingApplicationsModel> List = new List<LeasingApplicationsModel>();

            foreach (var item in context.LeasingApplications)
            {
                List.Add(new LeasingApplicationsModel(item));
            }
            return List;
        }
        internal static List<LeasingApplicationsModel> Search(string str, List<LeasingApplicationsModel> AllList)
        {
            List<LeasingApplicationsModel> searchList = new List<LeasingApplicationsModel>();

            foreach (var item in AllList)
            {
                if (Regex.IsMatch(item.SurnameNameMiddleName.Trim().ToLower(), (str.Trim().ToLower() + @"\w*")))
                    searchList.Add(item);
            }
            return searchList;
        }
        internal static bool AddLeasingApplicationsModel(string PhoneNumber, string Surname, string Name, string MiddleName) 
        {
            try 
            {
                LeasingAgencyContextDB context = new LeasingAgencyContextDB();
                int id = MainUser.getInstance().user.IdUser;
                context.LeasingApplications.First(a => a.IdUser == id);
                MessageBox.Show("Вы уже отправили заявку");
                return false;
            }
            catch 
            {
                LeasingAgencyContextDB context = new LeasingAgencyContextDB();
                
                LeasingApplications x = new LeasingApplications();
                x.IdUser = MainUser.getInstance().user.IdUser;
                x.PhoneNumber = PhoneNumber;
                x.Surname = Surname;
                x.NameUser = Name;
                x.MiddleName = MiddleName;
                x.DataApplications = Convert.ToString(DateTime.Now.ToLongDateString());
                context.LeasingApplications.Add(x);
                context.SaveChanges();
                MessageBox.Show("Заявка отправлена");
                return true;
            }
        }

        #region Команды

        #region DeletApplication

        public ICommand DeletApplication { get; }

        private bool CanDeletApplication(object p) => true;

        private void OnDeletApplication(object p)
        {
            int id = Convert.ToInt32(p);
            if(deleteApplication(id))
                WindowsManager.windowAdmin.FrameWindowUser.Navigate(new PageApplications());
        }

        #endregion 

        #region OpenInfoUser

        public ICommand OpenInfoUser { get; }

        private bool CanOpenInfoUser(object p) => true;

        private void OnOpenInfoUser(object p)
        {
            int id = Convert.ToInt32(p);
            WindowsManager.windowAdmin.FrameWindowUser.Navigate(new PageInfoAbautUser(id));
        }

        #endregion

        #endregion
    }
}
