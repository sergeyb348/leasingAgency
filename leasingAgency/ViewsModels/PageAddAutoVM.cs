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

        internal bool flagAutoImage = false;

        private BitmapImage _AutoImage;

        /// <summary> AutoImage </summary>

        public BitmapImage AutoImage
        {
            get => _AutoImage;

            set
            {
                flagAutoImage = value != null;
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
                if (value.Count() <= 20 && regexCheckBodyType(value) || value == "")
                {
                    flagBodyType = checkEmpt(value);
                    Set(ref _TextBoxBodyType, value);
                }

            }

        }

        private string _TextBoxBodyTypeError;

        /// <summary> TextBoxReleaseError </summary>

        public string TextBoxBodyTypeError
        {
            get => _TextBoxBodyTypeError;

            set => Set(ref _TextBoxBodyTypeError, value);
        }


        private bool regexCheckBodyType(string str)
        {
            if (!RegexForm.RegexNameFunc(str))
            {
                TextBoxBodyTypeError = "Tолько символы";
                return false;
            }
            else
            {
                TextBoxBodyTypeError = "";
                flagBodyType = true;
                return true;
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

                if ((value.Count() <= 4 && regexCheckRelease(value)) || value == "")
                {
                    flagRelease = checkEmpt(value);
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

        private bool regexCheckRelease(string str)
        {
            if (!RegexForm.RegexOnlyNumberFunc(str))
            {
                TextBoxReleaseError = "только числа";
                return false;
            }
            else
            {
                TextBoxReleaseError = "";
                flagRelease = true;
                return true;
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
                if (value.Count() <= 20 && regexCheckColor(value) || value == "")
                {
                    flagColor = checkEmpt(value);
                    Set(ref _TextBoxColor, value);
                }
            }

        }

        private string _TextBoxColorError;

        /// <summary> TextBoxReleaseError </summary>

        public string TextBoxColorError
        {
            get => _TextBoxColorError;

            set => Set(ref _TextBoxColorError, value);
        }


        private bool regexCheckColor(string str)
        {
            if (!RegexForm.RegexNameFunc(str))
            {
                TextBoxColorError = "Tолько символы";
                return false;
            }
            else
            {
                TextBoxColorError = "";
                flagColor = true;
                return true;
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
                if (value.Count() <= 7 && regexCheckPrice(value) || value == "")
                {
                    flagPrice = checkEmpt(value);
                    TextBlockInfoPriceMonth = Auto.ItemsInfoPriceMonth(Convert.ToInt32(TextBoxMonth), Convert.ToInt32(value));
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

        private bool regexCheckPrice(string str)
        {
            if (!RegexForm.RegexOnlyNumberFunc(str))
            {
                TextBoxPriceError = "только числа";
                return false;
            }
            else if (Convert.ToInt32(str) == 0)
            {
                TextBoxPriceError = "только натуральные числа";
                return false;
            }
            else
            {
                TextBoxPriceError = "";
                flagPrice = true;
                return true;
            }

        }

        #endregion

        #region TextBoxMonthPayment

        private string _TextBoxMonthPayment;

        private bool flagMonthPayment = false;

        /// <summary> TextBoxMonthPayment </summary>

        public string TextBoxMonthPayment
        {
            get => _TextBoxMonthPayment;

            set
            {
                if (value.Count() <= 3)
                {
                    flagMonthPayment = checkEmpt(value);
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
                if (value.Count() <= 3 && regexCheckMonth(value) || value == "")
                {
                    flagMonth = checkEmpt(value);
                    TextBlockInfoPriceMonth = Auto.ItemsInfoPriceMonth(Convert.ToInt32(value), Convert.ToInt32(TextBoxPrice));
                    Set(ref _TextBoxMonth, value);
                }
            }
        }

        private bool regexCheckMonth(string str)
        {
            if (!RegexForm.RegexOnlyNumberFunc(str))
            {
                TextBoxMonthPaymentError = "только числа";
                return false;
            }
            else if (Convert.ToInt32(str) == 0)
            {
                TextBoxMonthPaymentError = "только числа";
                return false;
            }
            else
            {
                TextBoxMonthPaymentError = "";
                flagMonth = true;
                return true;
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
            if (Auto.AddAuto(TextBoxBrandAuto, TextBoxModelAuto, TextBoxBodyType, TextBoxRelease, TextBoxColor, TextBoxPrice, TextBoxMonth, base64Image))
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

                AutoImage = ImageManager.ConvertBase64ToImage(base64Image);
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

