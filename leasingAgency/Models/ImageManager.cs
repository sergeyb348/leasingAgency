using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace leasingAgency.Models
{
    static class ImageManager
    {
        internal static BitmapImage ConvertBase64ToImage(string str) 
        {
            byte[] binaryData = Convert.FromBase64String(str);

            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.StreamSource = new MemoryStream(binaryData);
            bi.EndInit();
            return bi;
        }
    }
}
