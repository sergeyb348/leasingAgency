using leasingAgency.Infrastructure.Commands;
using leasingAgency.Models;
using leasingAgency.Views.MainWindow.PagesUserWindow;
using leasingAgency.ViewsModels.Base;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace leasingAgency.ViewsModels
{
    class PageAddAutoVM : ViewModel
    {

        #region Поля

        private bool checkEmpt(string str)
        {
            return str != "";
        }

        private void CreateTextBlockBrandAutoModelAuto(string strBrandAuto, string strModelAuto) 
        {
            TextBlockBrandAutoModelAuto = strBrandAuto + " " + strModelAuto;
        }

        private string base64Image;

        #region AutoImage

        private BitmapImage _AutoImage;

        /// <summary> AutoImage </summary>

        public BitmapImage AutoImage
        {
            get => _AutoImage;

            set
            {
                Set(ref _AutoImage, value);
            }
        }
        #endregion

        #region TextBoxBrandAuto

        private bool flagBrandAuto = false;

        private string _TextBoxBrandAuto;

        /// <summary> TextBoxBrandAuto </summary>

        public string TextBoxBrandAuto
        {
            get => _TextBoxBrandAuto;

            set
            {
                if (value.Count() <= 20) 
                {
                    CreateTextBlockBrandAutoModelAuto(value, TextBoxModelAuto);
                    flagBrandAuto = checkEmpt(value);
                    Set(ref _TextBoxBrandAuto, value);
                }
            }
        }
        #endregion

        #region TextBoxModelAuto

        private bool flagModelAuto = false;

        private string _TextBoxModelAuto;

        /// <summary> TextBoxModelAuto </summary>

        public string TextBoxModelAuto
        {
            get => _TextBoxModelAuto;

            set
            {
                if (value.Count() <= 20)
                {
                    CreateTextBlockBrandAutoModelAuto(TextBoxBrandAuto, value);
                    flagModelAuto = checkEmpt(value);
                    Set(ref _TextBoxModelAuto, value);
                }
            }    
        }
        #endregion

        #region TextBoxBodyType

        private bool flagBodyType = false;

        private string _TextBoxBodyType;

        /// <summary> TextBoxBodyType </summary>

        public string TextBoxBodyType
        {
            get => _TextBoxBodyType;

            set
            {
                if (value.Count() <= 20) 
                {
                    flagBodyType = checkEmpt(value);
                    Set(ref _TextBoxBodyType, value);
                }
                    
            }

        }
        #endregion

        #region TextBoxRelease

        private bool flagRelease = false;

        private string _TextBoxRelease;

        /// <summary> TextBoxRelease </summary>

        public string TextBoxRelease
        {
            get => _TextBoxRelease;

            set
            {
                if (value.Count() <= 4)
                {
                    regexCheckRelease(value);
                    Set(ref _TextBoxRelease, value);
                }
            }

        }

        private string _TextBoxReleaseError;

        /// <summary> TextBoxReleaseError </summary>

        public string TextBoxReleaseError
        {
            get => _TextBoxReleaseError;

            set => Set(ref _TextBoxReleaseError, value);
        }

        private void regexCheckRelease(string str)
        {
            if (!RegexForm.RegexOnlyNumberFunc(str))
            {
                TextBoxReleaseError = "только числа";
                flagRelease = false;
            }
            else
            {
                TextBoxReleaseError = "";
                flagRelease = true;
            }
        }
        #endregion

        #region TextBoxColor

        private bool flagColor = false;

        private string _TextBoxColor;

        /// <summary> TextBoxColor </summary>

        public string TextBoxColor
        {
            get => _TextBoxColor;

            set
            {
                if (value.Count() <= 20) 
                {
                    flagColor = checkEmpt(value);
                    Set(ref _TextBoxColor, value);
                }  
            }

        }
        #endregion

        #region TextBoxPrice

        private bool flagPrice = false;

        private string _TextBoxPrice;

        /// <summary> TextBoxPrice </summary>

        public string TextBoxPrice
        {
            get => _TextBoxPrice;

            set
            {
                if (value.Count() <= 7)
                {
                    regexCheckPrice(value);
                    TextBlockInfoPriceMonth = ItemsAutoVM.ItemsInfoPriceMonth(Convert.ToInt32(TextBoxMonth), Convert.ToInt32(value));
                    Set(ref _TextBoxPrice, value);
                    TextBoxPriceOut = value + " BYN";
                }    
            }

        }

        private string _TextBoxPriceError;

        /// <summary> TextBoxPriceError </summary>

        public string TextBoxPriceError
        {
            get => _TextBoxPriceError;

            set => Set(ref _TextBoxPriceError, value);
        }

        private string _TextBoxPriceOut;

        /// <summary> TextBoxPriceOut </summary>

        public string TextBoxPriceOut
        {
            get => _TextBoxPriceOut;

            set => Set(ref _TextBoxPriceOut, value);
        }

        private void regexCheckPrice(string str)
        {
            if (!RegexForm.RegexOnlyNumberFunc(str) && Convert.ToInt32(str) != 0)
            {
                TextBoxPriceError = "только числа";
                flagPrice = false;
            }
            else
            {
                TextBoxPriceError = "";
                flagPrice = true;
            }

        }

        #endregion

        #region TextBoxMonthPayment

        private string _TextBoxMonthPayment;

        /// <summary> TextBoxMonthPayment </summary>

        public string TextBoxMonthPayment
        {
            get => _TextBoxMonthPayment;

            set
            {
                if (value.Count() <= 3) 
                {
                    Set(ref _TextBoxMonthPayment, value);
                }
            }
        }

        private string _TextBoxMonthPaymentError;

        /// <summary> TextBoxMonthPayment </summary>

        public string TextBoxMonthPaymentError
        {
            get => _TextBoxMonthPaymentError;

            set => Set(ref _TextBoxMonthPaymentError, value);
        }

        #endregion

        #region TextBoxMonth

        private bool flagMonth = false;

        private string _TextBoxMonth;

        /// <summary> TextBoxMonthPayment </summary>

        public string TextBoxMonth
        {
            get => _TextBoxMonth;

            set
            {
                if (value.Count() <= 3)
                {
                    regexCheckMonth(value);
                    TextBlockInfoPriceMonth = ItemsAutoVM.ItemsInfoPriceMonth(Convert.ToInt32(value), Convert.ToInt32(TextBoxPrice));
                    Set(ref _TextBoxMonth, value);
                }
            }
        }

        private void regexCheckMonth(string str)
        {
            if (!RegexForm.RegexOnlyNumberFunc(str) && Convert.ToInt32(str) != 0)
            {
                TextBoxMonthPaymentError = "только числа";
                flagMonth = false;
            }
            else
            {
                TextBoxMonthPaymentError = "";
                flagMonth = true;
            }
        }

        #endregion

        #region TextBlockBrandAutoModelAuto

        private string _TextBlockBrandAutoModelAuto;

        /// <summary> TextBoxBrandAuto </summary>

        public string TextBlockBrandAutoModelAuto
        {
            get => _TextBlockBrandAutoModelAuto;

            set
            {
                Set(ref _TextBlockBrandAutoModelAuto, value);
            }
        }
        #endregion

        #region TextBlockInfoPriceMonth

        private string _TextBlockInfoPriceMonth;

        /// <summary> TextBlockInfoPriceMonth </summary>

        public string TextBlockInfoPriceMonth
        {
            get => _TextBlockInfoPriceMonth;

            set
            {
                Set(ref _TextBlockInfoPriceMonth, value);
            }
        }
        #endregion

        #endregion

        #region Команды

        #region AddAuto
        public ICommand AddAuto { get; }

        private bool CanAddAuto(object p) => flagBrandAuto && flagModelAuto && flagBodyType && flagRelease && flagColor && flagPrice && flagMonth && AutoImage != null;

        private void OnAddAuto(object p)
        {
            if (ItemsAutoManager.AddAuto(TextBoxBrandAuto, TextBoxModelAuto, TextBoxBodyType, TextBoxRelease, TextBoxColor, TextBoxPrice, TextBoxMonth, base64Image))
            {
                clearTextBox();
            }
        }
        #endregion

        #region ClearTextBox
        public ICommand ClearTextBox { get; }

        private bool CanClearTextBox(object p) => true;

        private void OnClearTextBox(object p)
        {
            clearTextBox();
        }

        private void clearTextBox()
        {
            WindowsManager.windowAdmin.FrameWindowUser.Navigate(new PageAddAuto());
        }

        public ICommand ImagePikcerDialogCommand { get; }

        private bool CanImagePikcerDialogCommand(object parameter) => true;

        private void OnImagePikcerDialogCommand(object parameter)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

            if (op.ShowDialog() == true)
            {
                var fileName = op.FileName;
                base64Image = Convert.ToBase64String(File.ReadAllBytes(fileName));

                byte[] binaryData = Convert.FromBase64String(base64Image);

                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(binaryData);
                bi.EndInit();

                AutoImage = bi;
            }
            #endregion

            #endregion

        }
        public PageAddAutoVM()
        {
            #region Команды
            AddAuto = new LambdaCommand(OnAddAuto, CanAddAuto);
            ClearTextBox = new LambdaCommand(OnClearTextBox, CanClearTextBox);
            ImagePikcerDialogCommand = new LambdaCommand(OnImagePikcerDialogCommand, CanImagePikcerDialogCommand);
            #endregion
        }
    }
}

