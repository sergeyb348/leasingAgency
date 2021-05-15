using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace leasingAgency.Models
{
    internal class Auto
    {
        public int IdAuto { get; set; }
        public string BrandAuto { get; set; }
        public string ModelAuto { get; set; }
        public string BodyType { get; set; }
        public int Release { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
        public int DurationPayment { get; set; }
        public int MonthPayment { get; set; }
        public BitmapImage ImgAuto { get; set; }
    }
}
