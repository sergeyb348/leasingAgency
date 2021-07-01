using leasingAgency.Infrastructure.Commands;
using leasingAgency.Views;
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
using System.Windows.Media.Imaging;

namespace leasingAgency.Models
{
    internal class Auto
    {

        public int IdAuto { get; set; }
        public string ModelAutoBrandAuto { get; set; }
        public string BodyType { get; set; }
        public string Release { get; set; }
        public string Color { get; set; }
        public string Price { get; set; }
        public string InfoPriceMonth { get; set; }
        public BitmapImage ImgAuto { get; set; }

        internal static string ItemsInfoPriceMonth(int strMonth, int strPrice)
        {
            try
            {
                int x = strPrice / strMonth;
                if (Convert.ToDouble(strMonth) / 12.0 >= 1 && strMonth % 12 != 0)
                {
                    if (strMonth / 12 == 1)
                        return "В месяц " + x + " BYN на год " + strMonth % 12 + " мес. ";
                    else if (strMonth / 12 <= 4)
                        return "В месяц " + x + " BYN на " + strMonth / 12 + " года " + strMonth % 12 + " мес. ";
                    else
                        return "В месяц " + x + " BYN на " + strMonth / 12 + " лет " + strMonth % 12 + " мес. ";
                }
                else if (Convert.ToDouble(strMonth) % 12.0 == 0)
                {
                    if (strMonth / 12 == 1)
                        return "В месяц " + x + " BYN на год ";
                    else if (strMonth / 12 <= 4)
                        return "В месяц " + x + " BYN на " + strMonth / 12 + " года ";
                    else
                        return "В месяц " + x + " BYN на " + strMonth / 12 + " лет ";
                }
                else if (Convert.ToDouble(strMonth) % 12.0 != 1)
                {
                    if (strMonth % 12 <= 4)
                        return "В месяц " + x + " BYN на " + strMonth % 12 + " месяца";
                    else
                        return "В месяц " + x + " BYN на " + strMonth % 12 + " месяцов";
                }
                else
                {
                    return "";
                }
            }
            catch
            {
                return "";
            }

        }

        internal Auto(AutoTable x) 
        {
            OpenEditAuto = new LambdaCommand(OnOpenEditAuto, CanOpenEditAuto);
            AddLikedAuto = new LambdaCommand(OnAddLikedAuto, CanAddLikedAuto);
            DeleteLikedAuto = new LambdaCommand(OnDeleteLikedAuto, CanDeleteLikedAuto);

            this.IdAuto = x.IdAuto;
            this.ModelAutoBrandAuto = (x.BrandAuto.Trim() + " " + x.ModelAuto.Trim());
            this.BodyType = x.BodyType.Trim();
            this.Release = Convert.ToString(x.Release);
            this.Color = x.Color.Trim();
            this.Price = Convert.ToString(x.Price) + " BYN";
            this.InfoPriceMonth = ItemsInfoPriceMonth(x.DurationPayment,x.Price);
            this. ImgAuto = ImageManager.ConvertBase64ToImage(x.ImgAuto);
        }

        #region команды

        #region AddLikedAuto

        public ICommand AddLikedAuto { get; }

        private bool CanAddLikedAuto(object p) => true;

        private void OnAddLikedAuto(object p)
        {
            if (addLikedAuto(Convert.ToInt32(p)))
                WindowsManager.windowUser.FrameWindowUser.Navigate(new ItemsAuto());
        }

        #endregion

        #region DeleteLikedAuto
        public ICommand DeleteLikedAuto { get; }

        private bool CanDeleteLikedAuto(object p) => true;

        private void OnDeleteLikedAuto(object p)
        {
            if (deleteLikedAuto(Convert.ToInt32(p)))
                WindowsManager.windowUser.FrameWindowUser.Navigate(new PageProfileUser());
        }

        #endregion

        #region OpenEditAuto
        public ICommand OpenEditAuto { get; }

        private bool CanOpenEditAuto(object p) => true;

        private void OnOpenEditAuto(object p)
        {
            int pId = Convert.ToInt32(p);
            LeasingAgencyContextDB context = new LeasingAgencyContextDB();
            var pAuto = context.AutoTable.First(x => x.IdAuto == pId);

            WindowsManager.windowAdmin.FrameWindowUser.Navigate(new PageEditAuto(pAuto));
        }

        #endregion

        #endregion

        internal static bool DeleteAuto(int Id) 
        {
            try 
            {
                LeasingAgencyContextDB context = new LeasingAgencyContextDB();

                context.AutoTable.First(x => x.IdAuto == Id).UserTable.Clear();

                context.AutoTable.Remove(context.AutoTable.First(x => x.IdAuto == Id));
                context.SaveChanges();

                MessageBox.Show("Авто успешно удаленно");
                return true;
            }
            catch
            {
                MessageBox.Show("Ошибка");
                return false;
            }
        }

        internal bool addLikedAuto(int Id) 
        {
            try
            {
                LeasingAgencyContextDB context = new LeasingAgencyContextDB();
                var auto = context.AutoTable.First(x => x.IdAuto == Id);
                var user = MainUser.getInstance().user;
                context.UserTable.First(x => x.IdUser == user.IdUser).AutoTable.Add(auto);
                context.SaveChanges();

                return true;
            }
            catch
            {
                MessageBox.Show("Вы уже отметели данное авто");
                return false;
            }
        }

        internal bool deleteLikedAuto(int Id) 
        {
            try
            {
                LeasingAgencyContextDB context = new LeasingAgencyContextDB();
                var auto = context.AutoTable.First(x => x.IdAuto == Id);
                var user = MainUser.getInstance().user;
                context.UserTable.First(x => x.IdUser == user.IdUser).AutoTable.Remove(auto);
                context.SaveChanges();

                return true;
            }
            catch
            {
                MessageBox.Show("Ошибка");
                return false;
            }
        }

        internal static List<Auto> GetListAuto()
        {
            List<Auto> ListAuto = new List<Auto>();
            LeasingAgencyContextDB context = new LeasingAgencyContextDB();

            foreach (var item in context.AutoTable)
            {
                ListAuto.Add(new Auto(item));
            }
            return ListAuto;
        }

        internal Auto GetAuto(int Id) 
        {
            LeasingAgencyContextDB context = new LeasingAgencyContextDB();
            AutoTable auto = context.AutoTable.First(x => x.IdAuto == Id);
            return new Auto(auto);
        }

        internal static List<Auto> GetListLikedAuto()
        {
            LeasingAgencyContextDB context = new LeasingAgencyContextDB();
            List<Auto> ListAuto = new List<Auto>();
            var user = MainUser.getInstance().user;

            foreach (var item in context.UserTable.First(x => x.IdUser == user.IdUser).AutoTable)
            {
                ListAuto.Add(new Auto(item));
            }
            return ListAuto;
        }

        internal static List<Auto> GetListLikedAuto(int Id)
        {
            LeasingAgencyContextDB context = new LeasingAgencyContextDB();
            List<Auto> ListAuto = new List<Auto>();

            foreach (var item in context.UserTable.First(x => x.IdUser == Id).AutoTable)
            {
                ListAuto.Add(new Auto(item));
            }
            return ListAuto;
        }

        internal static bool AddAuto(string BrandAuto, string modelAuto, string bodyType, string release, string color, string price, string durationPayment, string imgAuto)
        {
            try
            {
                LeasingAgencyContextDB context = new LeasingAgencyContextDB();
                AutoTable x = new AutoTable();
                x.BrandAuto = BrandAuto;
                x.ModelAuto = modelAuto;
                x.BodyType = bodyType;
                x.Release = Convert.ToInt32(release);
                x.Color = color;
                x.Price = Convert.ToInt32(price);
                x.DurationPayment = Convert.ToInt32(durationPayment);
                x.ImgAuto = imgAuto;
                x.MonthPayment = x.Price / x.DurationPayment;
                context.AutoTable.Add(x);
                context.SaveChanges();
                MessageBox.Show("Авто успешно добавленно");
                return true;
            }
            catch
            {
                MessageBox.Show("Ошибка");
                return false;
            }
        }

        internal static bool editAuto(int IdAuto, string brandAuto, string modelAuto, string bodyType, string release, string color, string price, string durationPayment, string imgAuto)
        {
            try 
            {
                LeasingAgencyContextDB context = new LeasingAgencyContextDB();
                AutoTable auto = context.AutoTable.First(x => x.IdAuto == IdAuto);

                auto.BrandAuto = brandAuto.Trim();
                auto.ModelAuto = modelAuto.Trim();
                auto.BodyType = bodyType.Trim();
                auto.Release = Convert.ToInt32( release.Trim());
                auto.Color = color.Trim();
                auto.Price =Convert.ToInt32( price.Trim());
                auto.DurationPayment =Convert.ToInt32( durationPayment.Trim());
                auto.ImgAuto = imgAuto;
                auto.MonthPayment = Convert.ToInt32(price.Trim()) / Convert.ToInt32(durationPayment.Trim());
                context.SaveChanges();
                return true;
            }
            catch 
            {
                MessageBox.Show("Ошибка");
                return false;
            }
            
        }

        internal static List<Auto> Search(string str, List<Auto> AllList, string from, string befor) 
        {
            List<Auto> searchList = new List<Auto>();

            if (from.Trim() != "" && befor.Trim() != "") 
            {
                int f = Convert.ToInt32(from);
                int b = Convert.ToInt32(befor);

                foreach (var item in AllList) 
                {
                    int p = Convert.ToInt32(item.Price.TrimEnd('B','Y','N') );
                    if (Regex.IsMatch(item.ModelAutoBrandAuto.Trim().ToLower(), (str.Trim().ToLower() + @"\w*")) && (p >= f) && (p <= b))
                        searchList.Add(item);
                }
            }
            else 
            {
                foreach (var item in AllList) 
                {
                    if (Regex.IsMatch(item.ModelAutoBrandAuto.Trim().ToLower(), (str.Trim().ToLower() + @"\w*")))
                        searchList.Add(item);
                }
            }
            return searchList;
        }

        internal static List<Auto> Search(string str, List<Auto> AllList)
        {
            List<Auto> searchList = new List<Auto>();

            foreach (var item in AllList)
            {
                    if (Regex.IsMatch(item.ModelAutoBrandAuto.Trim().ToLower(), (str.Trim().ToLower() + @"\w*")))
                        searchList.Add(item);
            }
            return searchList;
        }
    }
}
