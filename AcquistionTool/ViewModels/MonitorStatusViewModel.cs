using AcquistionTool.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcquistionTool.ViewModels
{
    public class MonitorStatusViewModel : BaseViewModels

    {
        public MonitorStatusViewModel()
        {           
            Initial();
            RunMonitorImage();          
        }
        private enum TypeImage
        {
            Image,
            FavoriteImage
        }
        private void Initial()
        {
            _lbTotalImage = "Image Found : 0";
            _lbFavoriteImage = "Favorite Images : 0";
            _lbCurrentStatus = "Status: Ready";
            CheckDirectory(pathFavoriteImageFolder);
        }

        private void CheckDirectory(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }
        }
        private void CheckNumberImage(string path, TypeImage typeImage)
        {
            int countImage = 0;
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            if (!directoryInfo.Exists)
            {
                LbCurrentStatus = "Status: Directory not found";
            }
            else
            {
                FileInfo[] files = directoryInfo.GetFiles();
                foreach (FileInfo file in files)
                {
                    if (file.Extension == ".jpg" || file.Extension == ".png" || file.Extension == ".bmp" || file.Extension == ".jepg" || file.Extension == ".gif")
                    {
                        countImage++;
                    }
                }
                LbCurrentStatus = "Status: Ready";
                if (typeImage == TypeImage.Image)
                {
                    LbTotalImage = "Image Found : " + countImage.ToString();
                }
                else
                {
                    LbImageFavorite = "Favorite Images : " + countImage.ToString();
                }
            }

        }

        public void MonitorImage()
        {
            while (isMonitoring)
            {
                pathImageFolder = BaseVariable.PathImage;
                CheckNumberImage(pathImageFolder, TypeImage.Image);
                CheckNumberImage(pathFavoriteImageFolder, TypeImage.FavoriteImage);
            }
        }

        private void RunMonitorImage()
        {
            Task.Factory.StartNew(MonitorImage);
        }

        #region Properties
        private string _lbTotalImage;
        private string _lbFavoriteImage;
        private string _lbCurrentStatus;
        private DirectoryInfo _directoryInfo;

        public string LbTotalImage
        {
            get { return _lbTotalImage; }
            set
            {
                _lbTotalImage = value;
                // OnPropertyChanged(nameof(LbTotalImage));
                OnPropertyChanged();
            }

        }

        public string LbImageFavorite
        {
            get { return _lbFavoriteImage; }
            set
            {
                _lbFavoriteImage = value;
                // OnPropertyChanged(nameof(LbImageFavorite));
                OnPropertyChanged();
            }
        }

        public string LbCurrentStatus
        {
            get { return _lbCurrentStatus; }
            set
            {
                _lbCurrentStatus = value;
                // OnPropertyChanged(nameof(_lbCurrentStatus));
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public bool isMonitoring = true;
        public string pathImageFolder = BaseVariable.PathImage;
        public string pathFavoriteImageFolder = BaseVariable.PathFavorite;
        #endregion
    }
}
