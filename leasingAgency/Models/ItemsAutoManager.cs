using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace leasingAgency.Models
{
    internal static class ItemsAutoManager
    {
        internal static bool AddAuto(string BrandAuto, string modelAuto, string bodyType, string release, string color, string price, string durationPayment, string imgAuto) 
        {
            try
            {
                leasingAgencyBD context = new leasingAgencyBD();
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
    }
}
