using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;
using System.IO;
using System.Windows;
using AcquistionTool.Base;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace AcquistionTool.ViewModels
{
    public class OpenFileViewModel : BaseViewModels
    {
       // private readonly BaseSystem _baseSystem;
        public OpenFileViewModel () 
        {       
            OpenFolerCommand = new RelayCommand<MainViewModels>(p => { OpenFolderDialog();}, p => true);
            ToggeFavoriteCommand = new RelayCommand<MainViewModels>(p => { OpenFavoriteFolder(); }, p => true);
            ExitCommand = new RelayCommand<MainViewModels>(p => { ExitApplication(); }, p => true);
        }


        public void OpenFolderDialog()
        {
            var dialog = new OpenFolderDialog()
            {
                Title = "Select Folder",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                Multiselect = false
            };

            string folderName = "";
            if (dialog.ShowDialog() == true)
            {
                folderName = dialog.FolderName;
                BaseVariable.PathImage = dialog.FolderName;
                DirectoryInfo directoryInfo = new DirectoryInfo(folderName);
                    if (!directoryInfo.Exists)
                    {
                        System.Windows.MessageBox.Show("Folder not found");
                        return;
                    }
                    else
                    {
                        BaseVariable.PathImage = folderName;
                        BaseVariable.ListImage.Clear();
                        foreach (var file in directoryInfo.GetFiles())
                        {
                            if (file.Extension == ".jpg" || file.Extension == ".png" || file.Extension == ".bmp" || file.Extension == ".jepg" || file.Extension == ".gif")
                            {
                                BitmapImage bitmapImage = new BitmapImage();
                                bitmapImage.BeginInit();
                                bitmapImage.UriSource = new Uri(file.FullName);
                                //MessageBox.Show(file.FullName);
                                bitmapImage.EndInit();
                                BaseVariable.ListImage.Add(bitmapImage);
                                   
                            }
                        }
                        BaseVariable.OnListFileNameChanged(BaseVariable.ListImage);    
                    }
                BaseVariable.isPutImage = true;
                }
            
        }

        public void OpenFavoriteFolder()
        {
            BaseVariable.isPutImage = false;
        }

        public void ExitApplication()
        {
            Application.Current.Shutdown();
        }

        #region Commands
        public ICommand OpenFolerCommand { get; set; }
        public ICommand ToggeFavoriteCommand { get; set; }

        public ICommand ExitCommand { get; set; }



        #endregion
    }
}
