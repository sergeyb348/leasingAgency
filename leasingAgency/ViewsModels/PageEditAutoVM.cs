//PageEditAutoVM
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
    class PageEditAutoVM : ViewModel
    {

        #region Поля

        private int IdAuto;

        private bool checkEmpt(string str)
        {
            return str.Trim() != "";
        }

        private void CreateTextBlockBrandAutoModelAuto(string strBrandAuto, string strModelAuto)
        {
            TextBlockBrandAutoModelAuto = strBrandAuto + " " + strModelAuto;
        }

        private string base64Image;

        #region AutoImage

        internal bool flagAutoImage = true;

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

        private bool flagBrandAuto = true;

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

        private bool flagModelAuto = true;

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

        private bool flagBodyType = true;

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

        private bool flagRelease = true;

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

        private bool flagColor = true;

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

        private bool flagPrice = true;

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

        private bool flagMonthPayment = true;

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

        private bool flagMonth = true;

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

        #region ImagePikcerDialogCommand
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

        }

        #endregion

        #region SaveAutoChanges
        public ICommand SaveAutoChanges { get; }

        private bool CanSaveAutoChanges(object parameter) => flagAutoImage && flagBodyType && flagBrandAuto && flagColor && flagModelAuto && flagMonth && flagMonthPayment && flagPrice && flagRelease;

        private void OnSaveAutoChanges(object parameter)
        {
            if (Auto.editAuto(IdAuto, TextBoxBrandAuto, TextBoxModelAuto, TextBoxBodyType, TextBoxRelease, TextBoxColor, TextBoxPrice, TextBoxMonth, base64Image))
                OpenItemsAutoAdmin();
        }
        #endregion

        #region Back
        public ICommand Back { get; }

        private bool CanBack(object parameter) => true;

        private void OnBack(object parameter)
        {
            OpenItemsAutoAdmin();
        }
        #endregion

        #region DeleteAuto
        public ICommand DeleteAuto { get; }

        private bool CanDeleteAuto(object parameter) => true;

        private void OnDeleteAuto(object parameter)
        {
            if (Auto.DeleteAuto(IdAuto))
                OpenItemsAutoAdmin();
        }
        #endregion

        internal static void OpenItemsAutoAdmin() 
        {
            WindowsManager.windowAdmin.FrameWindowUser.Navigate(new PageItemsAutoAdmin());
        }

        #endregion

        public PageEditAutoVM(AutoTable auto)
        {
            AutoImage = ImageManager.ConvertBase64ToImage(auto.ImgAuto.Trim());
            IdAuto = auto.IdAuto;
            TextBoxBrandAuto = auto.BrandAuto.Trim();
            TextBoxModelAuto = auto.ModelAuto.Trim();
            TextBoxBodyType = auto.BodyType.Trim();
            TextBoxRelease = Convert.ToString(auto.Release).Trim();
            TextBoxColor = auto.Color.Trim();
            TextBoxPrice = Convert.ToString(auto.Price).Trim();
            TextBoxMonth = Convert.ToString(auto.DurationPayment).Trim();
            base64Image = auto.ImgAuto.Trim();

            #region Команды
            ImagePikcerDialogCommand = new LambdaCommand(OnImagePikcerDialogCommand, CanImagePikcerDialogCommand);
            SaveAutoChanges = new LambdaCommand(OnSaveAutoChanges, CanSaveAutoChanges);
            Back = new LambdaCommand(OnBack, CanBack);
            DeleteAuto = new LambdaCommand(OnDeleteAuto, CanDeleteAuto);
            #endregion
        }
    }
}


