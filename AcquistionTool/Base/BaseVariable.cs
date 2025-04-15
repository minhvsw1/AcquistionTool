using AcquistionTool.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace AcquistionTool.Base
{
    public static class BaseVariable
    {
        public static string PathImage { get; set; } = @"C:\Users\Zbook 15 G2\source\repos\AcquistionTool_fix_nvk\AcquistionTool\AcquistionTool\bin\Debug\net8.0-windows\Image";
        public static string PathFavorite { get; set; } = @"C:\Users\Zbook 15 G2\source\repos\AcquistionTool_fix_nvk\AcquistionTool\AcquistionTool\bin\Debug\net8.0-windows\Favorite Images";

        public static OpenFileViewModel OpenFileViewModel { get; set; } = new OpenFileViewModel();
        public static MonitorStatusViewModel MonitorStatusViewModel { get; set; } = new MonitorStatusViewModel();
       
        public static List<BitmapImage> ListImage { get; set; } = new List<BitmapImage>();

        public static List<BitmapImage> ListImageFavorite { get; set; } = new List<BitmapImage>();

        public static bool isPutImage = false;

        public static event EventHandler<List<BitmapImage>> ListFileNameChanged;

        public static event EventHandler<BitmapImage> ImageChanged;

        public static void OnListFileNameChanged(List<BitmapImage> fileNames)
        {
            ListFileNameChanged?.Invoke(null, fileNames);
        }

        public static void OnImageInListChanged(List<BitmapImage> fileNames,int imageIndex)
        {
            ImageChanged?.Invoke(null, fileNames[imageIndex]);
        }
    }
}
